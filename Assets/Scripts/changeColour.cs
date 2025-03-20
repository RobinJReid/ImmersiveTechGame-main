using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColour : MonoBehaviour
{
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
        else {
            this.GetComponent<Renderer>().material = Mat1;
            isMat1 = true;
        }
    }
}
