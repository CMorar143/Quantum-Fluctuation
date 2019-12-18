using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMesh : MonoBehaviour
{
    public int height = 2;
    public float detailsScale = 5.0f;
    private List<GameObject> fluctuations = new List<GameObject>();
    
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    public int xSize = 10;
    public int zSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Create Mesh
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        CreateMesh();
    }

    void CreateMesh()
    {
        // Loop through all vertices and apply perlin noise
        for (int v = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise((x + this.transform.position.x) / detailsScale,
                                            (z + this.transform.position.z) / detailsScale) * height;

                vertices[v] = new Vector3(x, y, z);
                v++;

                // If the field fluctuation is high
                // Limit to 40% of the time
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

        // Create the triangles of the mesh
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

    // Gets called when plane is destroyed destroys the particle spawner
    private void OnDestroy()
    {
        for (int i = 0; i < fluctuations.Count; i++)
        {
            if (fluctuations[i] != null)
            {
                fluctuations[i].SetActive(false);
            }
        }
        fluctuations.Clear();
    }
}
