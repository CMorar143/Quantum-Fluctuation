using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject particles;
    private Transform newParticle;

    void Start()
    {
        newParticle = this.transform;
        //Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f), Quaternion.identity);
        StartCoroutine("CreateParticles");
    }

    IEnumerator CreateParticles()
    {
        while (true)
        {
            transform.rotation = transform.parent.transform.rotation;
            Vector3 rot = new Vector3(0, Random.Range(-25.0f, 25.0f), Random.Range(-25.0f, 25.0f));
            newParticle.Rotate(rot, Space.Self);

            // Pop into existence
            Instantiate(
                particles, 
                new Vector3(
                    transform.position.x + Random.Range(-0.3f, 0.3f), 
                    0, //transform.position.y + Random.Range(-0.2f, 0.2f), 
                    transform.position.z
                    ), 
                newParticle.rotation
            );

            //GameObject fluctuation = GameObject.Instantiate<GameObject>(particles);
            //fluctuation.transform.position = transform.position;// + new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.2f, 0.2f), 0);
            //fluctuation.transform.rotation = transform.rotation;
            yield return new WaitForSeconds(2.0f);
        }
    }
}
