using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CheckupGallery : MonoBehaviour
{
    [SerializeField] private CheckupGalleryItem checkupGalleryItemPrefab;
    [SerializeField] private Transform checkupContainer;

    private List<CheckupData> allCheckups;
    private List<CheckupGalleryItem> galleryItems;

    private void Awake()
    {
        galleryItems = new List<CheckupGalleryItem>();
    }

    /// <summary>
    /// Setup checkupGallery for given hive
    /// </summary>
    /// <param name="hiveID">hive ID</param>
    public void Setup(string hiveID)
    {
        string checkupPath = Path.Combine("CheckupData", hiveID);
        allCheckups = JsonLoader.LoadAllFilesInDirectory<CheckupData>(checkupPath);

        allCheckups = allCheckups.OrderBy
            (x => 
                DateTime.ParseExact(x.dateString, 
                "dd.MM.yyyy",
                System.Globalization.CultureInfo.InvariantCulture))
            .ToList();
        
        allCheckups.Reverse();

        foreach (CheckupData checkup in allCheckups)
        {
            CreateCheckupGalleryItem(checkup);
        }
    }

    private void CreateCheckupGalleryItem(CheckupData checkupData)
    {
        CheckupGalleryItem newCheckup = Instantiate(checkupGalleryItemPrefab, checkupContainer);
        newCheckup.Setup(checkupData);
        galleryItems.Add(newCheckup);
    }
}
