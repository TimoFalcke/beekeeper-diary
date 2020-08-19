using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Main script for the HiveOverview scene
/// </summary>
public class HiveScreen : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI hiveNameLabel;
    [SerializeField] TextMeshProUGUI hiveInfoLabel;
    [SerializeField] HiveGalleryItem hiveGalleryItem;
    [SerializeField] private CheckupGallery checkupGallery;

    [Header("References")] 
    [SerializeField] private CheckupDataModifier checkupDataModifier;
    
    void Start()
    {
        SetupCurrentHive();
    }

    /// <summary>
    /// Setup scene based on currenntHive (loaded from PlayerPrefs path)
    /// </summary>
    void SetupCurrentHive()
    {
        HiveData currentHive = 
            JsonLoader.LoadFromJSON<HiveData>(PlayerPrefs.GetString("CurrentHivePath"));

        // Setup texts
        hiveNameLabel.text = "Beute " + currentHive.number;
        hiveInfoLabel.text = 
            "Beute " + currentHive.number + "\n" +
            currentHive.location;

        hiveGalleryItem.Setup(currentHive);
        checkupGallery.Setup(currentHive.id);
    }

    /// <summary>
    /// Set CurrentCheckup path to "" to create a new Checkup in the Checkup scene -> called by "New Checkup" button
    /// </summary>
    public void ClearCurrentCheckupPath()
    {
        PlayerPrefs.SetString(checkupDataModifier.currentDataObjectPath, "");
    }
}
