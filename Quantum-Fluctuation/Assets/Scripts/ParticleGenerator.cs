using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject particles;

    void Start()
    {
        //Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f), Quaternion.identity);
        StartCoroutine("CreateParticles");
    }

    IEnumerator CreateParticles()
    {
        while (true)
        {
            Transform newParticle = transform;
            //newParticle.Rotate(0, Random.Range(-25.0f, 25.0f), Random.Range(-25.0f, 25.0f));

            // Pop into existence
            Instantiate(particles, new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f), Random.Range(-0.2f, 0.2f), transform.position.z), newParticle.rotation);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
