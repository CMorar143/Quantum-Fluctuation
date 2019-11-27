using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject particles;
    private Vector3 playerPos;

    void Start()
    {
        //Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f), Quaternion.identity);
        playerPos = transform.position;
        Instantiate(particles, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
    }
}
