using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckupCreator : DataObjectCreator<CheckupData>
{
    private HiveData currentHive;
    private DateTime today;

    [Header("Checkup UI References")] 
    [SerializeField] private TextMeshProUGUI hiveDateLabel;
    
    protected override void Awake()
    {
        currentHive = 
            JsonLoader.LoadFromJSON<HiveData>(PlayerPrefs.GetString("CurrentHivePath"));
        today = DateTime.Today;
        
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        
        hiveDateLabel.text = $"Beute {currentHive.number} | {dataObject.dateString} | {dataObject.beekeeper}";
    }

    protected override CheckupData CreateNewDataObject()
    {
        return new CheckupData()
        {
            id = PlayerPrefs.GetInt(dataModifier.countPlayerPrefsKey, 0).ToString(),
            hiveID = currentHive.id,
            beekeeper = PlayerPrefs.GetString("BeekeeperName", "unbekannt"),
            dateString = today.ToString("dd.MM.yyyy")
        };
    }

    protected override void OnSaveCompleted(CheckupData savedCheckupData)
    {
        base.OnSaveCompleted(savedCheckupData);
        
        // hiveManager.SetCurrentHive(newCheckupData);
        sceneLoader.LoadScene("HiveOverview");
    }
}
