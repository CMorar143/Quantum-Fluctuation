using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Grid
{
    private GameObject meshGrid;
    private float creationTime;

    public Grid(GameObject m, float ct)
    {
        meshGrid = m;
        creationTime = ct;
    }
}

public class MeshGenerator : MonoBehaviour
{
    public Transform player;
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int meshSize = 10;
    public int xSize = 10;
    public int zSize = 10;
    public float offsetX;
    public float offsetZ;

    Vector3 startPos;

    Hashtable grids = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetZ = Random.Range(0f, 9999f);

        mesh = CreateMesh();
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for (int x = -xSize; x < xSize; x++)
        {
            for (int z = -zSize; z < zSize; z++)
            {
                Mesh m = CreateMesh();
            }
        }
        
        this.transform.position = player.position + new Vector3(-xSize / 2, -3f, -zSize / 2);
    }

    Mesh CreateMesh()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int v = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(z * 0.3f + offsetZ + this.transform.position.z, x * 0.3f + offsetX + this.transform.position.x) * 2f;
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
        mesh.RecalculateBounds();

        return mesh;
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
        //mesh = new Mesh();
        //GetComponent<MeshFilter>().mesh = mesh;

        //vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        //for (int v = 0, z = 0; z <= zSize; z++)
        //{
        //    for (int x = 0; x <= xSize; x++)
        //    {
        //        float y = Mathf.PerlinNoise(z * 0.3f + offsetZ, x * 0.3f + offsetX) * 2f;
        //        vertices[v] = new Vector3(x, y, z);
        //        v++;
        //    }
        //}

        //triangles = new int[xSize * zSize * 6];

        //for (int tris = 0, verts = 0, z = 0; z < zSize; z++)
        //{
        //    for (int x = 0; x < xSize; x++)
        //    {
        //        triangles[0 + tris] = verts + 0;
        //        triangles[1 + tris] = verts + xSize + 1;
        //        triangles[2 + tris] = verts + 1;
        //        triangles[3 + tris] = verts + 1;
        //        triangles[4 + tris] = verts + xSize + 1;
        //        triangles[5 + tris] = verts + xSize + 2;

        //        verts++;
        //        tris += 6;
        //    }

        //    verts++;
        //}

        //mesh.Clear();
        //mesh.vertices = vertices;
        //mesh.triangles = triangles;

        //mesh.RecalculateNormals();
        //transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        offsetX += Time.deltaTime * Input.GetAxis("Vertical") * 5f;
        offsetZ += Time.deltaTime * -Input.GetAxis("Horizontal") * 5f;
    }
}
