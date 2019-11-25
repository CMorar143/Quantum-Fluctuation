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
        Instantiate(particles, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
