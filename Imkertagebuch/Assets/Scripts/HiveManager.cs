using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Runtime/Single Instance/HiveManager")]
public class HiveManager : ScriptableObject
{
    public HiveData currentHive;

    public List<HiveData> loadedHives;
}
