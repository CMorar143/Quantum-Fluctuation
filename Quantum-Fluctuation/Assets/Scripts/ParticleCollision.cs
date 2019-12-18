using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "matter")
        {
            Debug.Log("collision");
            // Pop out of existence
            Destroy(transform.parent.gameObject);
        }
    }
}
