using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class NotesScreen : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private bool initialized;

    private void OnEnable()
    {
        inputField.text = PlayerPrefs.GetString("notes", "");

        if (!initialized)
        {
            initialized = true;
            inputField.onValidateInput += SaveNoteText;
        }
    }

    private char SaveNoteText(string text, int charindex, char addedchar)
    {
        SaveNoteText();
        return addedchar;
    }

    public void SaveNoteText()
    {
        PlayerPrefs.SetString("notes", inputField.text);
    }

    public void Clear()
    {
        inputField.text = "";
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
