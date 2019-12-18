using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject particles;
    private Transform newParticle;
    public float freq = 0.8f;
    Vector3 rot;

    void Start()
    {
        newParticle = this.transform;
        StartCoroutine("CreateParticles");
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "matter")
        {
            Debug.Log("collision");

            // Pop out of existence
            Destroy(transform.parent.gameObject);
        }
    }

    IEnumerator CreateParticles()
    {
        while (true)
        {
            rot = new Vector3(0, 0, Random.Range(-35.0f, 35.0f));
            newParticle.Rotate(rot, Space.Self);
            
            // Pop into existence
            Instantiate(
                particles,
                new Vector3(
                    transform.position.x + Random.Range(-0.3f, 0.3f),
                    this.gameObject.transform.position.y,
                    transform.position.z
                    ),
                newParticle.rotation
            );

            transform.rotation = transform.parent.transform.rotation;

            yield return new WaitForSeconds(freq);
        }
    }
}
