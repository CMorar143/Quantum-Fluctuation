using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject particles;
    private Transform newParticle;
    public float freq = 0.8f;
    private Vector3 rot;
    private float matterColour;
    private float antiMatterColour;

    private void OnEnable()
    {
        newParticle = this.transform;
        StartCoroutine("CreateParticles");
    }

    IEnumerator CreateParticles()
    {
        while (true)
        {
            rot = new Vector3(0, 0, Random.Range(-35.0f, 35.0f));
            newParticle.Rotate(rot);
            
            // Pop into existence
            GameObject p  = (GameObject) Instantiate(
                              particles,
                              new Vector3(
                                  transform.position.x,
                                  this.gameObject.transform.position.y,
                                  transform.position.z
                                  ),
                              newParticle.rotation
                              );

            // Randomise colour
            matterColour = Random.value;
            antiMatterColour = (matterColour + 0.5f) % 1;
            p.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.HSVToRGB(matterColour, 1, 1);
            p.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.HSVToRGB(antiMatterColour, 1, 1);

            yield return new WaitForSeconds(freq);
        }
    }
}
