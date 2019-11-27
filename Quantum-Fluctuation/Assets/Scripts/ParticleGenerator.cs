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
        Instantiate(particles, new Vector3(transform.position.x + Random.Range(-0.4f, 0.4f), Random.Range(-0.3f, 0.2f), transform.position.z), transform.rotation);
    }
}
