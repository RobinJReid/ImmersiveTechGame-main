using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winCondition : MonoBehaviour
{
    [SerializeField] GameObject GhostTrapper;
    [SerializeField] GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player" && GhostTrapper.GetComponent<ghostTrapper>().GhostsCaught >= 6)
        {
            Player.transform.position = new Vector3(-25.97f, 3.051f, -10.065f);
        }
    }
}
