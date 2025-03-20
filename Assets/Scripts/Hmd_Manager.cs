using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hmd_Manager : MonoBehaviour
{
    [SerializeField] GameObject xrPlayer;
    [SerializeField] GameObject fpsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("using device" + XRSettings.loadedDeviceName);
        if (XRSettings.isDeviceActive || XRSettings.loadedDeviceName == "OpenXR Display")
        {
            fpsPlayer.SetActive(false);
            xrPlayer.SetActive(true);
        }
        else
        {
            fpsPlayer.SetActive(true);
            xrPlayer.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
