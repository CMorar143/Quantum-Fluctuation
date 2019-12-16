using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public Transform player;
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int v = 0, i = 0; i <= zSize; i++)
        {
            for (int j = 0; j <= xSize; j++)
            {
                float y = Mathf.PerlinNoise(i * 0.3f, j * 0.3f) * 2f;
                vertices[v] = new Vector3(j, y, i);
                v++;
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

        // Just for one quad
        //vertices = new Vector3[]
        //{
        //    new Vector3 (0,0,0),
        //    new Vector3 (0,0,1),
        //    new Vector3 (1,0,0),
        //    new Vector3 (1,0,1)
        //};

        //triangles = new int[]
        //{
        //    0, 1, 2,
        //    1, 3, 2
        //};

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    //private void OnDrawGizmos()
    //{
    //    if (vertices == null)
    //        return;

    //    for (int i = 0; i < vertices.Length; i++)
    //    {
    //        Gizmos.DrawSphere(vertices[i], 0.1f);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.position + new Vector3(-xSize/2, -2f, -zSize/2);
    }
}
