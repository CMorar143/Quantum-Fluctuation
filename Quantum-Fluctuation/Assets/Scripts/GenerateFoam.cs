using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFoam : MonoBehaviour
{
    int height = 5;
    float detailsScale = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] verts = mesh.vertices;

        for (int v = 0; v < verts.Length; v++)
        {
            verts[v].y = Mathf.PerlinNoise((verts[v].x + this.transform.position.x) / detailsScale,
                                           (verts[v].z + this.transform.position.z) / detailsScale) * height;
        }

        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
