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
    public float offsetX;
    public float offsetZ;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetZ = Random.Range(0f, 9999f);

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int v = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(z * 0.3f + offsetZ, x * 0.3f + offsetX) * 2f;
                vertices[v] = new Vector3(x, y, z);
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

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        this.transform.position = player.position + new Vector3(-xSize / 2, -3f, -zSize / 2);
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
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int v = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(z * 0.3f + offsetZ, x * 0.3f + offsetX) * 2f;
                vertices[v] = new Vector3(x, y, z);
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

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        //transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        offsetX += Time.deltaTime * Input.GetAxis("Vertical") * 5f;
    }
}
