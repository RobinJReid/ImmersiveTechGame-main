using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class handAnimator : MonoBehaviour
{

    [SerializeField] private NearFarInteractor nearFarInteractor;
    [SerializeField] private SkinnedMeshRenderer HandMesh;
    private void Awake()
    {
        nearFarInteractor.selectEntered.AddListener(OnGrab);
        nearFarInteractor.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("released");
        HandMesh.enabled = true;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("selected");
        HandMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
