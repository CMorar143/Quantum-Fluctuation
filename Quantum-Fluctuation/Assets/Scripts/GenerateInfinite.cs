using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Plane
{
    GameObject plane;
    public float creationTime;

    public Plane(GameObject p, float ct)
    {
        plane = p;
        creationTime = ct;
    }
}

public class GenerateInfinite : MonoBehaviour
{
    public GameObject foam;
    public GameObject player;

    int foamSize = 10;
    int halfPlanesX = 10;
    int halfPlanesz = 10;

    Vector3 startPos;

    Hashtable planes = new Hashtable();

    // Start is called before the first frame update
    private void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for (int x = 0; x < -halfPlanesX; x++)
        {
            for (int z = -halfPlanesz; z < halfPlanesz; z++)
            {
                Vector3 pos = new Vector3((x * foamSize + startPos.x), 0, (z * foamSize + startPos.z));

                GameObject p = (GameObject)Instantiate(foam, pos, Quaternion.identity);

                string planeName = "PLane_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                p.name = planeName;
                Plane plane = new Plane(p, updateTime);
                planes.Add(planeName, plane);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}