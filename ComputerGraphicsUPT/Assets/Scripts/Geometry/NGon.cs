using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGon : MonoBehaviour
{
    private Mesh customMesh;

    public int numOfSides = 8;
    public float radius = 1;
    //public float radius = 1f;

    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        // Vertices
        // locations of vertices
        Vector3[] verts = new Vector3[numOfSides];

        //verts[0] = new Vector3(0, 0, 0);//first vertex
        //Vector3 center = verts[0];
        //Debug.Log(verts.Length);
        //Debug.Log(numOfSides);

        for (int i = 0; i < verts.Length; i++)
        {
            verts[i].x = radius * Mathf.Sin((2 * Mathf.PI * i) / numOfSides);
            verts[i].y = radius * Mathf.Cos((2 * Mathf.PI * i) / numOfSides);
        }

        mesh.vertices = verts;

        //Triangles
        int numOfTriangles = numOfSides - 2;//ex: 4 - 2
        int indicesTemp = 0;
        //get length of indices
        for (int i = 0; i < numOfTriangles; i++){
            indicesTemp += 3;
        }

        int[] indices = new int[indicesTemp];//2

        int iPrev = 0;

        //                     2
        for (int i = 0; i < indices.Length; i += 3)
        {
            //Debug.Log(i);
            indices[i] = 0;
            //Debug.Log("indices " +i+ ": " + indices[0]);
            if (i < 3)
            {
                indices[i + 1] = i + 1;
                //Debug.Log("indices " + (i + 1) + ": " + indices[iPrev + 1]);
                indices[i + 2] = i + 2;
                //Debug.Log("indices " + (i + 2) + ": " + indices[iPrev + 2]);

            }
            if (i >= 3)
            {
                //Debug.Log("indices 0:" + indices[0]);
                indices[i + 1] = indices[i - 1];
                //Debug.Log("indices " + (i + 1) + ": " + indices[i - 1]);
                indices[i + 2] = indices[i - 1] + 1;
                //Debug.Log("indices "+ (i + 2) +": " + (indices[i - 1] + 1));
            }

            iPrev = indices[i + 2];

        }

        mesh.triangles = indices;

        // Normals
        Vector3[] norms = new Vector3[numOfSides];

        for(int i = 0; i < norms.Length; i++)
        {
            norms[i] = -Vector3.forward;
        }

        mesh.normals = norms;

        //texture cordinates
        // UVs, STs
        // defines how textures are mapped onto the surface
        Vector2[] UVs = new Vector2[numOfSides];

        for(int i = 0; i < UVs.Length; i++)
        {
            UVs[i].x = Mathf.Sin(radius * (2 * Mathf.PI * i) / numOfSides);
            UVs[i].y = Mathf.Cos(radius * (2 * Mathf.PI * i) / numOfSides);

        }

        mesh.uv = UVs;

        var filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;
        customMesh = mesh;
    }

    void OnDestroy()
    {
        // Clean up our mesh if we created it
        if (customMesh != null)
        {
            Destroy(customMesh);
        }
    }
}
