using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HiveGalleryItem : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI numberLabel;
    [SerializeField] TextMeshProUGUI lastCheckupDateLabel;
    [SerializeField] private GameObject visibilityToggle;

    [Header("References")]
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private HiveDataModifier hiveDataModifier;

    HiveData hiveData;
    private Button button;

    public bool HiveActive => hiveData.status == "active";

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Setup(HiveData data)
    {
        hiveData = data;
        numberLabel.text = data.number;
        if (button)
            button.interactable = HiveActive;
        
        // TODO: maybe don't load all checkups here?
        string checkupPath = Path.Combine("CheckupData", hiveData.id);
        List<CheckupData> allCheckups = JsonLoader.LoadAllFilesInDirectory<CheckupData>(checkupPath);

        if (allCheckups.Count > 0)
        {
            allCheckups = allCheckups.OrderBy
                (x =>
                    DateTime.ParseExact(x.dateString,
                        "dd.MM.yyyy",
                        System.Globalization.CultureInfo.InvariantCulture))
                .ToList();

            allCheckups.Reverse();

            lastCheckupDateLabel.text = allCheckups[0].dateString;
        }
        else
            lastCheckupDateLabel.text = "-";
    }

    public void LoadHiveScreen()
    {
        PlayerPrefs.SetString("CurrentHivePath", hiveDataModifier.DataObjectPath(hiveData));
        sceneLoader.LoadScene("HiveOverview");
    }

    public void ShowVisibilityToggle(bool show)
    {
        visibilityToggle.SetActive(show);
    }

    public void ChangeData(string key, string data)
    {
        hiveData = hiveDataModifier.UpdateData(hiveData, key, data);
        hiveDataModifier.SaveJson(hiveData, true);
        
        button.interactable = HiveActive;
    }
}
