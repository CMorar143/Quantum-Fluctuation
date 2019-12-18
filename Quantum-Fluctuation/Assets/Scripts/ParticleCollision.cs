using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    static public bool collided = false;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "matter")
        {
            //Debug.Log("collision");
            collided = true;
            // Pop out of existence
            //Destroy(transform.parent.gameObject);
        }
    }
}
