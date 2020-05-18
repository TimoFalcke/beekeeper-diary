using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HiveData
{
    [Header("General")]
    [Tooltip("Beutennummer")]
    public string number;
    [Tooltip("Standmaß")]
    public string size;
    [Tooltip("Ort")]
    public int location;

    [Header("Queen")]

    [Tooltip("Zuchtbuch-Nr.")]
    public int queenBreedingBookNumber;
    [Tooltip("Zeichen")]
    public string queenSign;
    [Tooltip("Jahrgang")]
    public string queenBirthyear;
    [Tooltip("Rasse-Linie")]
    public string queenRace;

    [Header("Drones")]

    [Tooltip("Zuchtbuch-Nr.")]
    public int dronesBreedingBookNumber;
    [Tooltip("gemeinsame Mutter")]
    public int dronesSharedMother;
    [Tooltip("Großmutter")]
    public int dronesGrandmother;
    [Tooltip("Belegstelle")]
    public int dronesPlaceOfReference;
    [Tooltip("Rasse-Linie")]
    public int dronesRace;
    [Tooltip("Zugesetzt")]
    public System.DateTime dronesAddedDate;


}
