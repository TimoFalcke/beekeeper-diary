using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Struct representing the HiveData .json files
/// </summary>
[System.Serializable]
public struct HiveData
{
    [Header("General")] [Tooltip("Status - active / inactive")]
    public string status;
    [Tooltip("Beuten ID")]
    public string id;
    [Tooltip("Beutennummer")]
    public string number;
    [Tooltip("Standmaß")]
    public string size;
    [Tooltip("Ort")]
    public string location;

    [Header("Queen")]

    [Tooltip("Zuchtbuch-Nr.")]
    public string queen_breedingBookNumber;
    [Tooltip("Zeichen")]
    public string queen_sign;
    [Tooltip("Jahrgang")]
    public string queen_birthyear;
    [Tooltip("Rasse-Linie")]
    public string queen_race;

    [Header("Drones")]

    [Tooltip("Zuchtbuch-Nr.")]
    public string drones_breedingBookNumber;
    [Tooltip("gemeinsame Mutter")]
    public string drones_sharedMother;
    [Tooltip("Großmutter")]
    public string drones_grandmother;
    [Tooltip("Belegstelle")]
    public string drones_placeOfReference;
    [Tooltip("Rasse-Linie")]
    public string drones_race;
    [Tooltip("Zugesetzt")]
    public string drones_addedDate;


}
