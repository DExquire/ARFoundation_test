using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject modelPrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject model;
    private ARTrackedImageManager aRTrackedImageManager;

    public void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            model = Instantiate(modelPrefab, image.transform);
            model.transform.position += prefabOffset;
        }

        
    }
}
