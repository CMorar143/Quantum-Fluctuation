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
        //Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f), Quaternion.identity);
        StartCoroutine("CreateParticles");
    }

    private void Update()
    {

    }

    IEnumerator CreateParticles()
    {
        while (true)
        {
            rot = new Vector3(0, 0, Random.Range(-35.0f, 35.0f));
            newParticle.Rotate(rot, Space.Self);

            //rotUp = Quaternion.AngleAxis(Random.Range(-25.0f, 25.0f), Vector3.up);
            //rotForward = Quaternion.AngleAxis(Random.Range(-75.0f, 75.0f), Vector3.forward);
            //rotRight = Quaternion.AngleAxis(Random.Range(-25.0f, 25.0f), Vector3.right);

            //Quaternion rot = Quaternion.identity * transform.rotation;
            //rot = rotForward * rot;
            //rot = rot * 

            // Pop into existence
            Instantiate(
                particles,
                new Vector3(
                    transform.position.x,// + Random.Range(-0.3f, 0.3f),
                    this.gameObject.transform.position.y,
                    transform.position.z
                    ),
                newParticle.rotation
            );

            // Doesn't seem to work
            //GameObject p = (GameObject)Instantiate<GameObject>(particles);
            //p.transform.SetParent(transform);

            transform.rotation = transform.parent.transform.rotation;

            yield return new WaitForSeconds(freq);
        }
    }
}
