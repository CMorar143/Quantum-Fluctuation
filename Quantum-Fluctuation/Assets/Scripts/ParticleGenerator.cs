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

    IEnumerator CreateParticles()
    {
        while (true)
        {
            rot = new Vector3(0, 0, Random.Range(-35.0f, 35.0f));
            newParticle.Rotate(rot, Space.Self);
            
            // Pop into existence
            GameObject p  = (GameObject) Instantiate(
                              particles,
                              new Vector3(
                                  transform.position.x + Random.Range(-0.3f, 0.3f),
                                  this.gameObject.transform.position.y,
                                  transform.position.z
                                  ),
                              newParticle.rotation
                              );

            transform.rotation = transform.parent.transform.rotation;

            float matterColour = Random.value;
            float antiMatterColour = (matterColour + 0.5f) % 1;

            p.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.HSVToRGB(matterColour, 1, 1);
            p.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.HSVToRGB(antiMatterColour, 1, 1);

            yield return new WaitForSeconds(freq);
        }
    }
}
