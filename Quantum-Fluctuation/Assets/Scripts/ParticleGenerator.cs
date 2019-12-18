using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject particles;
    private Transform newParticle;
    public float freq = 0.8f;
    List<GameObject> ParticlePairs = new List<GameObject>();
    Vector3 rot;

    void Start()
    {
        newParticle = this.transform;
        StartCoroutine("CreateParticles");
    }

    IEnumerator CreateParticles()
    {
        while (true)
        {
            //rot = new Vector3(0, 0, Random.Range(-35.0f, 35.0f));
            //newParticle.Rotate(rot, Space.Self);
            
            //// Pop into existence
            //GameObject p  = (GameObject) Instantiate(
            //                  particles,
            //                  new Vector3(
            //                      transform.position.x,
            //                      this.gameObject.transform.position.y,
            //                      transform.position.z
            //                      ),
            //                  newParticle.rotation
            //                  );

            float matterColour = Random.value;
            float antiMatterColour = (matterColour + 0.5f) % 1;

            GameObject newParticlePair = ParticlePool.GetParticlePair();
            if (newParticlePair != null)
            {
                newParticlePair.transform.position = this.transform.position;
                newParticlePair.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.HSVToRGB(matterColour, 1, 1);
                newParticlePair.transform.GetChild(1).GetComponent<Renderer>().material.color = Color.HSVToRGB(antiMatterColour, 1, 1);
                newParticlePair.SetActive(true);
                ParticlePairs.Add(newParticlePair);
                newParticlePair.transform.SetParent(this.transform);
            }

            if (ParticleCollision.collided)
            {
                Debug.Log("collided was true");
                for (int i = 0; i < ParticlePairs.Count; i++)
                {
                    if (ParticlePairs[i] != null)
                    {
                        ParticlePairs[i].SetActive(false);
                    }
                    ParticlePairs.Clear();
                }
            }

            yield return new WaitForSeconds(freq);
        }
    }
}
