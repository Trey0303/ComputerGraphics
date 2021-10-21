using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeProceduralGeneration : MonoBehaviour
{
    private Mesh customMesh;
    //private Mesh customMesh;
    public int numSegments;
    public int numFaces;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        var mesh = new Mesh();
        ////Double Loop: used to create the positions and normals
        Vector3[] verts = new Vector3[numSegments * numFaces];
        Vector3[] normals = new Vector3[numSegments * numFaces];
        // get the increment per face around the tube in radians 
        float deltaPhi = Mathf.PI * 2.0f / numFaces;
        for (int i = 0; i < numSegments; i++)
        {
            //int prevIndex = i == 0 ? 0 : i - 1;
            //int nextIndex = i == numSegments - 1 ? numSegments - 1 : i + 1;
            //// figure out the local basis vectors
            //Vector3 zAxis = (pts[nextIndex] - pts[prevIndex]).normalized;
            //Vector3 xAxis = Vector3.Cross(Vector3.up, zAxis).normalized;
            //Vector3 yAxis = Vector3.Cross(zAxis, xAxis).normalized;

            for (int j = 0; j < numFaces; j++)
            {
                //creates faces in the form of a circle
                int index = i * numFaces + j;
                float phi = j * deltaPhi;
                //???
                normals[index] = Vector3.right * Mathf.Cos(phi) + Vector3.forward * Mathf.Sin(phi);
                //central spine
                Vector3 centre = i * Vector3.up;
                verts[index] = centre + normals[index] * radius;
            }
        }
        mesh.vertices = verts;
        mesh.normals = normals;

        ////UV coordinates and index buffer
        Vector2[] uvs = new Vector2[numSegments * numFaces];
        int k = 0;
        int[] indices = new int[(numSegments - 1) * numFaces * 6];
        for (int i = 0; i < numSegments - 1; i++)
        {
            for (int j = 0; j < numFaces; j++)
            {
                //
                int ibase = i * numFaces + j;
                uvs[ibase] = new Vector2(((float)i) / ((float)numSegments - 1), ((float)j) / ((float)numFaces));
                // do the wraparound for the last face to join back on to the first
                int inext = ibase + 1;
                if (j == numFaces - 1)
                {
                    inext -= numFaces;
                }

                //contruct traingles?
                indices[k] = ibase;//0
                k++;
                indices[k] = ibase + numFaces;//8
                k++;
                indices[k] = inext;//1
                k++;
                indices[k] = inext;//1
                k++;
                indices[k] = ibase + numFaces;//8
                k++;
                indices[k] = inext + numFaces;//9
                k++;

            }
        }
        
        mesh.uv = uvs;
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);

        // find our MeshFilter
        MeshFilter mf = GetComponent<MeshFilter>();

        mf.mesh = mesh;
        customMesh = mesh;

        mesh.RecalculateBounds();
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
