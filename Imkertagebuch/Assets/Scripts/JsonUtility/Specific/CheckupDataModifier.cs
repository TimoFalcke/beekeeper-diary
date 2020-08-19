using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Json/CheckupDataNodifier")]
public class CheckupDataModifier : JsonModifier<CheckupData>
{
    protected override string DataObjectName(CheckupData dataObject)
    {
        return $"Checkup_{dataObject.id}";
    }

    public override CheckupData UpdateData(CheckupData dataObject, string key, string data)
    {
        switch (key)
        {
            // info
            
            case "beekeeper":
                dataObject.beekeeper = data;
                break;
            
            // status
            
            case "status_occupiedCombs":
                dataObject.status_occupiedCombs = data;
                break;
            
            case "status_broodCombs":
                dataObject.status_broodCombs = data;
                break;
            
            case "status_broodEggs":
                dataObject.status_broodEggs = data;
                break;
            
            case "status_broodOpen":
                dataObject.status_broodOpen = data;
                break;
            
            case "status_broodCovered":
                dataObject.status_broodCovered = data;
                break;
            
            case "status_food":
                dataObject.status_food = data;
                break;
            
            case "status_combSeating":
                dataObject.status_combSeating = data;
                break;
            
            case "status_broodPosition":
                dataObject.status_broodPosition = data;
                break;
            
            case "status_temper":
                dataObject.status_temper = data;
                break;
            
            // added / taken
            
            case "added_emptyCombs":
                dataObject.added_emptyCombs = data;
                break;
            
            case "added_foundations":
                dataObject.added_foundations = data;
                break;
            
            case "added_broodCombs":
                dataObject.added_broodCombs = data;
                break;
            
            case "added_droneFrames":
                dataObject.added_droneFrames = data;
                break;
            
            case "added_bees":
                dataObject.added_bees = data;
                break;
                
            case "added_honey":
                dataObject.added_honey = data;
                break;
            
            case "added_food":
                dataObject.added_food = data;
                break;
            
            case "added_foodDescription":
                dataObject.added_foodDescription = data;
                break;
            
            // environment
            
            case "environment_weather":
                dataObject.environment_weather = data;
                break;
            
            case "environment_flowers":
                dataObject.environment_flowers = data;
                break;
            
            // notes
            
            case "notes":
                dataObject.notes = data;
                break;
        }

        return dataObject;
    }

    public override string GetData(CheckupData dataObject, string key)
    {
        switch (key)
        {
            // info
            
            case "beekeeper":
                return dataObject.beekeeper;
            
            // status
            
            case "status_occupiedCombs":
                return dataObject.status_occupiedCombs;
            
            case "status_broodCombs":
                return dataObject.status_broodCombs;
            
            case "status_broodEggs":
                return dataObject.status_broodEggs;
            
            case "status_broodOpen":
                return dataObject.status_broodOpen;
            
            case "status_broodCovered":
                return dataObject.status_broodCovered;
            
            case "status_food":
                return dataObject.status_food;
            
            case "status_combSeating":
                return dataObject.status_combSeating;
            
            case "status_broodPosition":
                return dataObject.status_broodPosition;
            
            case "status_temper":
                return dataObject.status_temper;
            
            // added / taken
            
            case "added_emptyCombs":
                return dataObject.added_emptyCombs;
            
            case "added_foundations":
                return dataObject.added_foundations;
            
            case "added_broodCombs":
                return dataObject.added_broodCombs;
            
            case "added_droneFrames":
                return dataObject.added_droneFrames;
            
            case "added_bees":
                return dataObject.added_bees;
                
            case "added_honey":
                return dataObject.added_honey;
            
            case "added_food":
                return dataObject.added_food;
            
            case "added_foodDescription":
                return dataObject.added_foodDescription;
            
            // environment
            
            case "environment_weather":
                return dataObject.environment_weather;
            
            case "environment_flowers":
                return dataObject.environment_flowers;
            
            // notes
            
            case "notes":
                return dataObject.notes;
        }

        Debug.LogError($"{this} - key {key} not implemented");
        return "";
    }

    public override string DataObjectPath(CheckupData dataObject)
    {
        return Path.Combine(folderPath, dataObject.hiveID, DataObjectName(dataObject) + ".json");
    }
}
