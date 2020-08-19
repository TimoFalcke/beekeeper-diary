using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Struct representing the CheckupData .json files
/// </summary>
[System.Serializable]
public struct CheckupData
{
    [Header("Info")]
    [Tooltip("Unique Checkup ID")]
    public string id;
    [Tooltip("Corresponding Hive ID")]
    public string hiveID;
    [Tooltip("Imker, der die Durchsicht durchgeführt hat")]
    public string beekeeper;
    [Tooltip("Datum")] 
    public string dateString;
    
    [Header("General Status")]
    [Tooltip("Belegte Waben")]
    public string status_occupiedCombs;
    [Tooltip("Brutwaben")]
    public string status_broodCombs;
    [Tooltip("Brut(Eier)")]
    public string status_broodEggs;
    [Tooltip("Brut(offen")]
    public string status_broodOpen;
    [Tooltip("Brut(verdeckelt)")]
    public string status_broodCovered;
    [Tooltip("Futter")]
    public string status_food;
    [Tooltip("Wabensitz. Wert von 1 bis 10")]
    public string status_combSeating;
    [Tooltip("Brutposition")]
    public string status_broodPosition;
    [Tooltip("Sanftmut")]
    public string status_temper;

    [Header("added / taken")]
    [Tooltip("Leerwaben")]
    public string added_emptyCombs;
    [Tooltip("Mittelwände")]
    public string added_foundations;
    [Tooltip("Brutwaben")]
    public string added_broodCombs;
    [Tooltip("Drohnenrahmen")]
    public string added_droneFrames;
    [Tooltip("Bienen kg")]
    public string added_bees;
    [Tooltip("Honig kg")]
    public string added_honey;
    [Tooltip("Einfütterung kg")]
    public string added_food;
    [Tooltip("Einfütterung Sorte")]
    public string added_foodDescription;

    [Header("Environment")]
    [Tooltip("Wetterbeobachtung")]
    public string environment_weather;
    [Tooltip("Tracht")]
    public string environment_flowers;

    [Header("Further Notes")]
    [Tooltip("Anmerkungen")]
    public string notes;



}
