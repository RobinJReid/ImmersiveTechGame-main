using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour
{
    [SerializeField] GameObject GhostTrapper;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player" && GhostTrapper.GetComponent<ghostTrapper>().GhostsCaught >= 5)
        {
            this.gameObject.SetActive(false);
        }
    }
}
