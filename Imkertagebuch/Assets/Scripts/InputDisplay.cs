using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputDisplay : MonoBehaviour
{
    public string inputDataType;

    [Header("References")]
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text label;

    public event Action<string, string> OnValueChanged;

    private void Start()
    {
        inputField.onEndEdit.AddListener(DataEntered);
    }

    void DataEntered(string inputFieldData)
    {
        OnValueChanged?.Invoke(inputDataType, inputFieldData);
    }

    public void SetObligatory()
    {
        label.text += " <color=#BD4932>*</color>";
    }

    public void SetInputFieldText(string data)
    {
        inputField.text = data;
        inputField.onEndEdit.Invoke(data);
    } 
}
