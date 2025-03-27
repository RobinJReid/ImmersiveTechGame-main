using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Comfort;

public class Health : MonoBehaviour
{
    [SerializeField] int health;

    [SerializeField] Material Mat1;
    [SerializeField] Material Mat2;
    private bool isMat1;
    [SerializeField] GameObject GhostTrapper;

    public void ChangeHealth(int amount) 
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("Thing is dead");
            if (this.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("MainScene");
            }
            else 
            {
                Destroy(this.gameObject);
                GhostTrapper.GetComponent<ghostTrapper>().ChangeCount(1);
            }

        }
    }
}
