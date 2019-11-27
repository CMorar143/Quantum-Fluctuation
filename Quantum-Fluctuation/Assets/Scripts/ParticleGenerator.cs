using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject particles;
    

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        GameObject p = Instantiate(particles, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        p.transform.parent = this.transform;

        //Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f), Quaternion.identity);
    }
}
