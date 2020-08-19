using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base class to access and edit JSON objects (HiveData, CheckupData)
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class DataObjectCreator<T> : MonoBehaviour
{
    [SerializeField] protected T dataObject;
    
    [Header("Configuration")]
    [SerializeField] protected string[] obligatoryItems;
    
    [Header("References")]
    [SerializeField] protected Button submitButton;
    [SerializeField] protected TextMeshProUGUI title;
    [SerializeField] protected SceneLoader sceneLoader;
    [SerializeField] protected JsonModifier<T> dataModifier;

    private InputDisplay[] inputDisplays;
    private Dictionary<string, bool> obligatoryFieldFilled;
    private Dictionary<string, InputDisplay> inputDisplaysByDataType;

    /// <summary>
    /// Initialize references, initialize dataObject
    /// </summary>
    protected virtual void Awake()
    {
        obligatoryFieldFilled = new Dictionary<string, bool>();
        inputDisplaysByDataType = new Dictionary<string, InputDisplay>();
        
        // load existing dataObject if PlayerPrefs variable is set
        if (PlayerPrefs.GetString(dataModifier.currentDataObjectPath, "") != "")
        {
            dataObject = JsonLoader.LoadFromJSON<T>(
                PlayerPrefs.GetString(dataModifier.currentDataObjectPath));
            OnDataObjectLoaded();
        }
        // create new dataObject
        else
        {
            dataObject = CreateNewDataObject();
        }
    }
    
    /// <summary>
    /// Initialize InputFields in the scene, initialize obligatory fields, assign event listeners
    /// </summary>
    protected virtual void Start()
    {
        inputDisplays = FindObjectsOfType<InputDisplay>();

        FillInputFields();

        foreach (InputDisplay inputDisplay in inputDisplays)
        {
            inputDisplaysByDataType.Add(inputDisplay.inputDataType, inputDisplay);
            inputDisplay.OnValueChanged += UpdateData;
        }

        foreach (string obligatoryDataField in obligatoryItems)
        {
            obligatoryFieldFilled.Add(obligatoryDataField, 
                !string.IsNullOrWhiteSpace(dataModifier.GetData(dataObject, obligatoryDataField)));
            inputDisplaysByDataType[obligatoryDataField].SetObligatory();
        }

        submitButton.onClick.AddListener(CreateJson);
        if (obligatoryItems.Length > 0)
            submitButton.interactable = false;
        
        dataModifier.OnSaveCompleted += OnSaveCompleted;
    }

    /// <summary>
    /// Called when a dataObject was loaded on Awake (instead of creating a new one)
    /// </summary>
    protected virtual void OnDataObjectLoaded()
    {
    }

    protected abstract T CreateNewDataObject();
    
    /// <summary>
    /// Fill input fields in the scene with data of loaded dataObject
    /// </summary>
    protected void FillInputFields()
    {
        foreach (InputDisplay inputDisplay in inputDisplays)
        {
            inputDisplay.SetInputFieldText(dataModifier.GetData(dataObject, inputDisplay.inputDataType));
        }
    }
    
    /// <summary>
    /// Remove event listeners
    /// </summary>
    protected virtual void OnDestroy()
    {
        foreach (InputDisplay inputDisplay in inputDisplays)
        {
            inputDisplay.OnValueChanged -= UpdateData;
        }
        dataModifier.OnSaveCompleted -= OnSaveCompleted;
    }
    
    /// <summary>
    /// Called when the dataObject has been saved -> update created count (used as ID)
    /// </summary>
    /// <param name="savedCheckupData">saved dataObject</param>
    protected virtual void OnSaveCompleted(T savedCheckupData)
    {
        PlayerPrefs.SetInt(dataModifier.countPlayerPrefsKey, PlayerPrefs.GetInt(dataModifier.countPlayerPrefsKey, 0) + 1);
        submitButton.interactable = false;
    }

    /// <summary>
    /// Change data of the dataObject
    /// </summary>
    /// <param name="key">key (same as json key)</param>
    /// <param name="data">value</param>
    void UpdateData(string key, string data)
    {
        if (obligatoryFieldFilled.ContainsKey(key))
        {
            obligatoryFieldFilled[key] = !string.IsNullOrWhiteSpace(data);
            bool allObligatoryFieldsFilled = true;
            foreach (KeyValuePair<string, bool> obligatoryField in obligatoryFieldFilled)
            {
                if (obligatoryField.Value == false)
                {
                    allObligatoryFieldsFilled = false;
                    break;
                }
            }
            submitButton.interactable = allObligatoryFieldsFilled;
        }
        
        dataObject = dataModifier.UpdateData(dataObject, key, data);
    }
    
    /// <summary>
    /// Save dataObject as .json
    /// </summary>
    void CreateJson()
    {
        dataModifier.SaveJson(dataObject, true);
    }
}
