using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script for scene that shows the gallery of all Hives (start scene)
/// </summary>
public class AllHivesScreen : MonoBehaviour
{
    [SerializeField] private List<HiveData> allHiveData;

    [SerializeField] private Transform newHiveButton;

    private HiveGallery hiveGallery;

    private void Start()
    {
        hiveGallery = FindObjectOfType<HiveGallery>();
        Setup();
    }

    /// <summary>
    /// Load HiveData, setup hive gallery
    /// </summary>
    void Setup()
    {
        // Load all Hive Data
        allHiveData = JsonLoader.LoadAllFilesInDirectory<HiveData>("HiveData");
        hiveGallery.Setup(allHiveData);
        
        newHiveButton.SetAsLastSibling();
    }

    /// <summary>
    /// Edit mode: create new hives, show / hide existing hives. Called by Edit Button in TopBar
    /// </summary>
    public void ToggleEditMode()
    {
        bool activateEditMode = !newHiveButton.gameObject.activeInHierarchy;
        newHiveButton.gameObject.SetActive(activateEditMode);
        hiveGallery.ShowInactiveHives(activateEditMode);
    }

    /// <summary>
    /// Set CurrentHivePath to "" -> create a new Hive when loading HiveInitialization scene
    /// </summary>
    public void EmptyCurrentHivePath()
    {
        PlayerPrefs.SetString("CurrentHivePath", "");
    }
}
