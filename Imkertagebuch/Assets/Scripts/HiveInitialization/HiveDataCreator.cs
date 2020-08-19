using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HiveDataCreator : DataObjectCreator<HiveData>
{
    protected override HiveData CreateNewDataObject()
    {
        return new HiveData()
        {
            id = PlayerPrefs.GetInt("HiveCount", 0).ToString(),
            status = "active"
        };
    }

    protected override void OnDataObjectLoaded()
    {
        title.text = $"Beute {dataObject.number} anpassen";
    }

    protected override void OnSaveCompleted(HiveData savedCheckupData)
    {
        base.OnSaveCompleted(savedCheckupData);
        
        PlayerPrefs.SetString(dataModifier.currentDataObjectPath, dataModifier.DataObjectPath(savedCheckupData));
        sceneLoader.LoadScene("HiveOverview");
    }
}
