using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Gallery that displays all Hives in the scene
/// </summary>
public class HiveGallery : MonoBehaviour
{
    [SerializeField] HiveGalleryItem hiveGalleryItemPrefab;
    [SerializeField] private Transform hiveGalleryContainer;

    List<HiveGalleryItem> galleryItems = new List<HiveGalleryItem>();

    /// <summary>
    /// Setup hive gallery based on HiveData list
    /// </summary>
    /// <param name="hives">HiveData list</param>
    public void Setup(List<HiveData> hives)
    {
        foreach (HiveData hiveData in hives)
        {
            CreateHiveGalleryItem(hiveData);
        }

        ShowInactiveHives(false);
    }

    /// <summary>
    /// Create new HiveGalleryItem based on HiveData
    /// </summary>
    /// <param name="hiveData">HiveData of the wanted HiveGalleryItem</param>
    private void CreateHiveGalleryItem(HiveData hiveData)
    {
        HiveGalleryItem newHive = Instantiate(hiveGalleryItemPrefab, hiveGalleryContainer);
        newHive.Setup(hiveData);
        galleryItems.Add(newHive);
    }

    /// <summary>
    /// Show or hide hives that have been deactivated
    /// </summary>
    /// <param name="show">true: show inactive, false: hide inactive</param>
    public void ShowInactiveHives(bool show)
    {
        foreach (HiveGalleryItem galleryItem in galleryItems)
        {
            galleryItem.gameObject.SetActive(show || galleryItem.HiveActive);
            galleryItem.ShowVisibilityToggle(show);
        }
    }
}
