using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ghostDetector : MonoBehaviour
{
    private float Value;
    [SerializeField] public TMP_Text GhostText;
    private bool nearGhost;
    private bool canCaptureGhost;
    // Start is called before the first frame update

    public void Start()
    {
        nearGhost = false;
        canCaptureGhost = false;
    }

    // Update is called once per frame


    public void Temp()
    {
        if (nearGhost)
        {
            Value = Random.Range(00.0f, 2.0f);
        }
        else if (canCaptureGhost)
        {
            Value = Random.Range(2.0f, 4.0f);
        }
        else
        {
            Value = Random.Range(4.0f, 6.0f);
        }
        Debug.Log(Value);
        GhostText.text = Value.ToString("F2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GhostNear")
        {
            nearGhost = true;
        }
        if (other.gameObject.tag == "GhostFar")
        {
            canCaptureGhost = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GhostNear")
        {
            nearGhost = false;
        }
        if (other.gameObject.tag == "GhostFar")
        {
            canCaptureGhost = false;
        }
    }
    public void ClearGhostStatus()
    {
        nearGhost = false;
        canCaptureGhost = false;
    }
}
