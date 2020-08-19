using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileScreen : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    
    public void Show()
    {
        gameObject.SetActive(true);
        inputField.text = PlayerPrefs.GetString("BeekeeperName", "");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateBeekeeperName(string beekeeperName)
    {
        PlayerPrefs.SetString("BeekeeperName", beekeeperName);

        BeekeperBar beekeeperBar = FindObjectOfType<BeekeperBar>();
        if (beekeeperBar)
            beekeeperBar.UpdateNameLabel();
    }
}
