using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Comfort;

public class Beam : MonoBehaviour
{
    private bool inGhost;

    [SerializeField] Material Mat1;
    [SerializeField] Material Mat2;
    private bool isMat1;
    public AudioSource Beeper;

    public void Start()
    {
        Beeper = GetComponent<AudioSource>();
    }
    public void ChangeMaterial()
    {
        if (isMat1)
        {
            this.GetComponent<Renderer>().material = Mat2;
            isMat1 = false;
        }
        else
        {
            this.GetComponent<Renderer>().material = Mat1;
            isMat1 = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost") 
        {
            ChangeMaterial();
            Beeper.Play(0);
            inGhost = true;
            other.gameObject.GetComponent<Health>().ChangeHealth(1);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            inGhost = false;
            ChangeMaterial();
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (inGhost && other.gameObject.tag == "Ghost") 
        { 
            other.gameObject.GetComponent<Health>().ChangeHealth(2);
            Beeper.Play(0); 
        }
    }
}
