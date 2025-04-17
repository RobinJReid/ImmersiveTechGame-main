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
    public float neededMag;
    public bool canThrow;

    private AudioSource HitAudio;

    public void Start()
    {
        HitAudio = GetComponent<AudioSource>();
        canThrow = true;
    }


        private void OnTriggerEnter(Collider other)
    {
        

      
        
        if (other.gameObject.tag == "Ghost" && canThrow)
        {
            rb = GetComponent<Rigidbody>();
            Vector3 direction = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            rb.AddForce(direction, ForceMode.Impulse);

            // code by chatgpt REFERENCE LATER MY GOD
            float absX = Mathf.Abs(direction.x);
            float absY = Mathf.Abs(direction.y);
            float absZ = Mathf.Abs(direction.z);

            // Find the largest value
            float maxComponent = Mathf.Max(absX, absY, absZ);

            // Assign the original signed value

            if (maxComponent == absX) furthestValue = Mathf.Abs(direction.x);
            else if (maxComponent == absY) furthestValue = Mathf.Abs(direction.y);
            else furthestValue = Mathf.Abs(direction.z);
            waitForTime();



        }
        if (other.gameObject.tag == "player")
        {
            if (rb.velocity.magnitude > 0.5f) 
            {
                int damage = (int)furthestValue;
                other.gameObject.GetComponent<Health>().ChangeHealth(damage);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > neededMag && collision.gameObject.tag != "Ghost" && collision.gameObject.tag != "GhostNear" && collision.gameObject.tag != "GhostFar" && collision.gameObject.tag != "player")
        {
            HitAudio.volume = collision.relativeVelocity.magnitude/20;
            
            HitAudio.Play();
            
        }
    }

    IEnumerator waitForTime()
    {
        canThrow = false;
        yield return new WaitForSeconds(50f);
        canThrow = true;

    }

}
