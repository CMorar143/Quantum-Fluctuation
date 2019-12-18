using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    static int numParticles = 1000;
    public GameObject particlePair;
    static GameObject[] particlePairs;

    static int numFluctuations = 80;
    public GameObject fluctuation;
    static GameObject[] fluctuations;


    // Start is called before the first frame update
    void Start()
    {
        fluctuations = new GameObject[numFluctuations];
        for (int i = 0; i < numFluctuations; i++)
        {
            fluctuations[i] = (GameObject)Instantiate(fluctuation, Vector3.zero, Quaternion.identity);
            fluctuations[i].SetActive(false);
        }

        particlePairs = new GameObject[numParticles];
        for (int i = 0; i < numParticles; i++)
        {
            particlePairs[i] = (GameObject)Instantiate(particlePair, Vector3.zero, Quaternion.identity);
            particlePairs[i].SetActive(false);
        }

    }

    // Looping through the pool of particles
    // returning any that are inactive
    static public GameObject GetParticlePairs()
    {
        for (int i = 0; i < numParticles; i++)
        {
            if (!particlePairs[i].activeSelf)
            {
                return particlePairs[i];
            }
        }

        // All particles in the pool are being used
        return null;
    }

    // Looping through the pool of fluctuations
    // returning any that are inactive
    static public GameObject GetFluctuation()
    {
        for (int i = 0; i < numFluctuations; i++)
        {
            if (!fluctuations[i].activeSelf)
            {
                return fluctuations[i];
            }
        }

        // All fluctuations in the pool are being used
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
