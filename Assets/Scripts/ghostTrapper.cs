using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ghostTrapper : MonoBehaviour
{
    [SerializeField] GameObject Beam;
    private bool BeamActive;
    [SerializeField] public TMP_Text GhostText;
    public int GhostsCaught;

    private void Start()
    {
        BeamActive = false;
        Beam.SetActive(false);
    }
    public void TurnOn()
    {
        if (BeamActive)
        {
            BeamActive = false;
            Beam.SetActive(false);
        }
        else 
        {
            BeamActive = true;
            Beam.SetActive(true);
        }

    }
    public void ChangeCount(int amount)
    {
        GhostsCaught += amount;
        GhostText.text = GhostsCaught.ToString("F2");
    }
}
