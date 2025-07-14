using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnOnDesk : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private PlaneClassification classification;
    [SerializeField] private GameObject maquete;
    [SerializeField] private InputActionReference trigger;
    void OnEnable()
    {
        planeManager.planesChanged += SetupPlane;
    }
    void OnDisable()
    {
        planeManager.planesChanged -= SetupPlane;
    }

    private void SetupPlane(ARPlanesChangedEventArgs args)
    {
        List<ARPlane> newPlanes = args.added;
        foreach (ARPlane plane in newPlanes)
        {
            Renderer renderer = plane.GetComponent<Renderer>();
            Destroy(renderer);
            if (plane.classification == classification)
            {
                plane.AddComponent<CrestDetector>();
                plane.GetComponent<CrestDetector>().maquete = maquete;
                plane.GetComponent<CrestDetector>().triggerSpawn = trigger;
            }
        }
    }
}
