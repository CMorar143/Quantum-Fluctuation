using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    private static int numFluctuations = 150;
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
    }

    // Looping through the pool of trees
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
}
