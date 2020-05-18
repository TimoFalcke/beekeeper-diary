using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldValidator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Color normalColor;
    [SerializeField] Color filledColor;

    TMP_InputField inputField;
    Image inputFieldBg;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
        inputFieldBg = GetComponent<Image>();
    }

    private void Start()
    {
        inputField.onEndEdit.AddListener(OnEndEdit);
        inputField.onValidateInput += ValidateInput;
    }

    private char ValidateInput(string text, int charIndex, char addedChar)
    {
        // custom validation here
        return addedChar;
    }

    private void OnEndEdit(string value)
    {
        if (value != "")
            inputFieldBg.color = filledColor;
        else
            inputFieldBg.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inputFieldBg.color = normalColor;
    }
}
