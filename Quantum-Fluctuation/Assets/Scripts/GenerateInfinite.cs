using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Foam
{
    public GameObject plane;
    public float creationTime;

    public Foam(GameObject p, float ct)
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
    int halfPlanesX = 7;
    int halfPlanesZ = 7;

    Vector3 startPos;

    Hashtable planes = new Hashtable();

    // Start is called before the first frame update
    private void Start()
    {
        //this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        // Timestamp each newly created plane or update the timestamp
        // of a plane that's still in range
        float updateTime = Time.realtimeSinceStartup;

        for (int x = -halfPlanesX; x < halfPlanesX; x++)
        {
            for (int z = -halfPlanesZ; z < halfPlanesZ; z++)
            {
                Vector3 pos = new Vector3((x * foamSize + startPos.x), this.gameObject.transform.position.y, (z * foamSize + startPos.z));

                GameObject p = (GameObject)Instantiate(foam, pos, Quaternion.identity);

                string planeName = "PLane_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                p.name = planeName;
                Foam plane = new Foam(p, updateTime);
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
                    Vector3 pos = new Vector3((x * foamSize + playerX), this.gameObject.transform.position.y, (z * foamSize + playerZ));
                    string planeName = "PLane_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    if(!planes.ContainsKey(planeName))
                    {
                        GameObject p = (GameObject)Instantiate(foam, pos, Quaternion.identity);
                        p.name = planeName;
                        Foam plane = new Foam(p, updateTime);
                        planes.Add(planeName, plane);
                    }

                    else
                    {
                        (planes[planeName] as Foam).creationTime = updateTime;
                    }
                }
            }

            // Destroy all planes that have outdated timestamps
            // Put valid planes in a hashtable
            Hashtable newFoam = new Hashtable();
            foreach(Foam pl in planes.Values)
            {
                if(pl.creationTime != updateTime)
                {
                    // Delete plane
                    Destroy(pl.plane);
                }

                else
                {
                    newFoam.Add(pl.plane.name, pl);
                }
            }

            // Copy new hashtable contents to the working hashtable
            planes = newFoam;

            startPos = player.transform.position;
        }
    }
}