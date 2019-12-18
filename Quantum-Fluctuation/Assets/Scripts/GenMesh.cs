using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMesh : MonoBehaviour
{
    int height = 2;
    float detailsScale = 5.0f;
    List<GameObject> fluctuations = new List<GameObject>();
    
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    public int meshSize = 20;
    public int xSize = 10;
    public int zSize = 10;
    public float offsetX;
    public float offsetZ;

    // Start is called before the first frame update
    void Start()
    {
        // Create Mesh
        CreateMesh();
    }

    void CreateMesh()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int v = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise((x + this.transform.position.x) / detailsScale,
                                            (z + this.transform.position.z) / detailsScale) * height;

                vertices[v] = new Vector3(x, y, z);
                v++;

                if (y > 1.7 && Random.Range(0, 100) < 40)
                {
                    GameObject newFluctuation = ParticlePool.GetFluctuation();
                    if (newFluctuation != null)
                    {
                        Vector3 pos = new Vector3(x + this.transform.position.x,
                                                  y,
                                                  z + this.transform.position.z);
                        newFluctuation.transform.position = pos;
                        newFluctuation.SetActive(true);
                        fluctuations.Add(newFluctuation);
                    }
                }
            }
        }

        triangles = new int[xSize * zSize * 6];

        for (int tris = 0, verts = 0, z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[0 + tris] = verts + 0;
                triangles[1 + tris] = verts + xSize + 1;
                triangles[2 + tris] = verts + 1;
                triangles[3 + tris] = verts + 1;
                triangles[4 + tris] = verts + xSize + 1;
                triangles[5 + tris] = verts + xSize + 2;

                verts++;
                tris += 6;
            }

            verts++;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    // Gets called when plane is destroyed
    private void OnDestroy()
    {
        Debug.Log("destroyed");
        for (int i = 0; i < fluctuations.Count; i++)
        {
            if (fluctuations[i] != null)
            {
                fluctuations[i].SetActive(false);
            }
        }
        fluctuations.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
