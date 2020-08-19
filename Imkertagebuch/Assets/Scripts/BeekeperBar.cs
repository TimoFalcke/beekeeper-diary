using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeekeperBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameLabel;

    private void Start()
    {
        UpdateNameLabel();
    }

    public void UpdateNameLabel()
    {
        string beekeeperName = PlayerPrefs.GetString("BeekeeperName", "unbekannt");
        if (beekeeperName == "")
            beekeeperName = "unbekannt";
        
        nameLabel.text = $"Imker: {beekeeperName}";
    }
}
