using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckupGalleryItem : MonoBehaviour
{
    [SerializeField] private CheckupData checkupData;

    [Header("Components")] 
    [SerializeField] private TextMeshProUGUI dateLabel;
    [SerializeField] private TextMeshProUGUI beekeeperLabel;

    [Header("References")] 
    [SerializeField] private CheckupDataModifier dataModifier;

    public void Setup(CheckupData checkupData)
    {
        this.checkupData = checkupData;
        dateLabel.text = checkupData.dateString;
        beekeeperLabel.text = checkupData.beekeeper;
    }

    public void SetCurrentCheckup()
    {
        PlayerPrefs.SetString(dataModifier.currentDataObjectPath, dataModifier.DataObjectPath(checkupData));
    }
}
