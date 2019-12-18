using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "matter")
        {
            // Pop out of existence
            Destroy(transform.parent.gameObject);
        }
    }
}
