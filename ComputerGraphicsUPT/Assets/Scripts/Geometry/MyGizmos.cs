using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmos : MonoBehaviour
{
    

    public float radius = .12f;

    Vector3[] vertices;
    void OnDrawGizmos()
    {
        //The SharedMesh property refers to your actual mesh asset, so changes to the mesh will affect all objects that use that mesh reference
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        if(mesh != null)
        {
            vertices = mesh.vertices;
            //for each vertex in the mesh
            if (vertices != null)
            {
                foreach (Vector3 vertex in vertices)
                {
                    //draw a sphere on at vertex position
                    Gizmos.color = Color.green;
                    Vector3 worldPos = transform.TransformPoint(vertex);
                    Gizmos.DrawSphere(worldPos, radius);
                }

            }

        }

    }
}
