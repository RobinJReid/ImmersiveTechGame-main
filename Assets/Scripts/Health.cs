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
    private AudioSource HitAudio;

    private void Start()
    {
        HitAudio = GetComponent<AudioSource>();
    }

    public void ChangeHealth(int amount) 
    {
        health -= amount;
        if (this.gameObject.tag == "player")
        {
            HitAudio.Play(0);
        }

        if (health <= 0)
        {
            Debug.Log("Thing is dead");
            if (this.gameObject.tag == "player")
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
