using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityToggle : MonoBehaviour
{
    [SerializeField] private HiveGalleryItem galleryItem;

    [SerializeField] private GameObject openEye;
    [SerializeField] private GameObject closedEye;

    private bool currentlyActive;
    
    private void OnEnable()
    {
        currentlyActive = galleryItem.HiveActive;

        UpdateButtonVisuals();
    }

    void UpdateButtonVisuals()
    {
        openEye.SetActive(!currentlyActive);
        closedEye.SetActive(currentlyActive);
    }

    public void ToggleVisibility()
    {
        currentlyActive = !currentlyActive;
        galleryItem.ChangeData("status", currentlyActive ? "active" : "inactive");
        UpdateButtonVisuals();
    }
}
