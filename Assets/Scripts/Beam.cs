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
        ChangeMaterial();
        if (other.gameObject.tag == "Ghost") 
        {
            inGhost = true;
            other.gameObject.GetComponent<Health>().ChangeHealth(1);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            inGhost = false;
        }
        ChangeMaterial();
    }
    private void OnTriggerStay(Collider other)
    {
        if (inGhost) { other.gameObject.GetComponent<Health>().ChangeHealth(2); }
    }
}
