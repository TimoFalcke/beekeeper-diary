using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Json/HiveDataModifier")]
public class HiveDataModifier : JsonModifier<HiveData>
{
    protected override string DataObjectName(HiveData dataObject)
    {
        return $"HiveData_{dataObject.id}";
    }

    public override HiveData UpdateData(HiveData dataObject, string key, string data)
    {
        switch (key)
        {
            case "status":
                dataObject.status = data;
                break;
            
            case "number":
                dataObject.number = data;
                break;

            case "size":
                dataObject.size = data;
                break;

            case "location":
                dataObject.location = data;
                break;

            case "queen_breedingBookNumber":
                dataObject.queen_breedingBookNumber = data;
                break;

            case "queen_sign":
                dataObject.queen_sign = data;
                break;

            case "queen_birthyear":
                dataObject.queen_birthyear = data;
                break;

            case "queen_race":
                dataObject.queen_race = data;
                break;

            case "drones_breedingBookNumber":
                dataObject.drones_breedingBookNumber = data;
                break;

            case "drones_sharedMother":
                dataObject.drones_sharedMother = data;
                break;

            case "drones_grandmother":
                dataObject.drones_grandmother = data;
                break;

            case "drones_placeOfReference":
                dataObject.drones_placeOfReference = data;
                break;

            case "drones_race":
                dataObject.drones_race = data;
                break;

            case "drones_addedDate":
                dataObject.drones_addedDate = data;
                break;
        }
        return dataObject;
    }

    public override string GetData(HiveData dataObject, string key)
    {
        switch (key)
        {
            case "status":
                return dataObject.status;
            
            case "number":
                return dataObject.number;

            case "size":
                return dataObject.size;

            case "location":
                return dataObject.location;

            case "queen_breedingBookNumber":
                return dataObject.queen_breedingBookNumber;

            case "queen_sign":
                return dataObject.queen_sign;

            case "queen_birthyear":
                return dataObject.queen_birthyear;

            case "queen_race":
                return dataObject.queen_race;

            case "drones_breedingBookNumber":
                return dataObject.drones_breedingBookNumber;

            case "drones_sharedMother":
                return dataObject.drones_sharedMother;

            case "drones_grandmother":
                return dataObject.drones_grandmother;

            case "drones_placeOfReference":
                return dataObject.drones_placeOfReference;

            case "drones_race":
                return dataObject.drones_race;

            case "drones_addedDate":
                return dataObject.drones_addedDate;
        }

        Debug.LogError($"{this} - key {key} not implemented");
        return "";
    }
}
