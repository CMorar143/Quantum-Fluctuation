using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    int numFluctuations = 80;
    public GameObject fluctuation;
    GameObject[] fluctuations;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
