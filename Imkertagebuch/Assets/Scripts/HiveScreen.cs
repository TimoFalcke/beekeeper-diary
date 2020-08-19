using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void ClearCurrentCheckupPath()
    {
        PlayerPrefs.SetString(checkupDataModifier.currentDataObjectPath, "");
    }
}
