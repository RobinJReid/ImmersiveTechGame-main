using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GhostThrowable : MonoBehaviour
{
    public float thrust = 50.0f;
    private Vector3 direction;
    public Rigidbody rb;
    public float furthestValue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost" || other.gameObject.tag == "GhostNear")
        {
            rb = GetComponent<Rigidbody>();
            Vector3 direction = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            rb.AddForce(direction, ForceMode.Impulse);
            Debug.Log(direction);

            // code by chatgpt REFERENCE LATER MY GOD
            float absX = Mathf.Abs(direction.x);
            float absY = Mathf.Abs(direction.y);
            float absZ = Mathf.Abs(direction.z);

            // Find the largest value
            float maxComponent = Mathf.Max(absX, absY, absZ);

            // Assign the original signed value

            if (maxComponent == absX) furthestValue = direction.x;
            else if (maxComponent == absY) furthestValue = direction.y;
            else furthestValue = direction.z;

            Debug.Log("Furthest value: " + furthestValue);


        }
        if (other.gameObject.tag == "player")
        {
            int damage;
            damage = (int)furthestValue;
            other.gameObject.GetComponent<Health>().ChangeHealth(damage);
        }
    }


    }
