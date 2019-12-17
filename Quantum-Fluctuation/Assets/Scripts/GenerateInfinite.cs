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
    int halfPlanesZ = 10;

    Vector3 startPos;

    Hashtable planes = new Hashtable();

    // Start is called before the first frame update
    private void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for (int x = -halfPlanesX; x < halfPlanesX; x++)
        {
            for (int z = -halfPlanesZ; z < halfPlanesZ; z++)
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
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if(Mathf.Abs(xMove) >= foamSize || Mathf.Abs(zMove) >= foamSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            int playerX = (int)(Mathf.Floor(player.transform.position.x / foamSize) * foamSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z / foamSize) * foamSize);

            for (int x = -halfPlanesX; x < halfPlanesX; x++)
            {
                for (int z = -halfPlanesZ; z < halfPlanesZ; z++)
                {
                    Vector3 pos = new Vector3((x * foamSize + playerX), 0, (z * foamSize + playerZ));
                    string planeName = "PLane_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    if(!planes.ContainsKey(planeName))
                    {
                        GameObject p = (GameObject)Instantiate(foam, pos, Quaternion.identity);
                        p.name = planeName;
                        Plane plane = new Plane(p, updateTime);
                        planes.Add(planeName, plane);
                    }

                    else
                    {
                        (planes[planeName] as Plane).creationTime = updateTime;
                    }
                }
            }
        }
    }
}