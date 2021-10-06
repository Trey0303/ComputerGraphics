using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPentagon : MonoBehaviour
{
    private Mesh customMesh;
    //public float radius = 1f;

    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        // Vertices
        // locations of vertices
        Vector3[] verts = new Vector3[5];

        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(-.5f, 1, 0);
        verts[2] = new Vector3(1.5f, 1, 0);
        verts[3] = new Vector3(1, 0, 0);
        verts[4] = new Vector3(.5f, 2, 0);
        mesh.vertices = verts;

        //Triangles
        /*Next, you need to set up the triangles. A quad consists of two triangles, each made up of three points in the vertex array you created earlier. 
         * To specify the points, you define each triangle as three indices of the the vertex array. For example, 
         * the lower left triangle for this quad uses index 0, 2, and 1 which corresponds to coordinates (0, 0, 0), (0, height, 0), and (width, 0, 0) from the vertex array. 
         * The ordering is important because you must order the corners clockwise. The upper right triangle uses index 2, 3, and 1.*/
        int[] indices = new int[9];

        //bottom triangle
        indices[0] = 0;
        indices[1] = 2;
        indices[2] = 3;

        //middle triangle
        indices[3] = 0;
        indices[4] = 1;
        indices[5] = 2;

        //top triangle
        indices[6] = 1;
        indices[7] = 4;
        indices[8] = 2;

        mesh.triangles = indices;

        // Normals
        // describes how light bounces off the surface (at the vertex level)
        //
        // note that this data is interpolated across the surface of the triangle
        Vector3[] norms = new Vector3[5];

        norms[0] = Vector3.forward;
        norms[1] = Vector3.forward;
        norms[2] = Vector3.forward;
        norms[3] = Vector3.forward;
        norms[4] = Vector3.forward;

        mesh.normals = norms;

        //texture cordinates
        // UVs, STs
        // defines how textures are mapped onto the surface
        Vector2[] UVs = new Vector2[5];

        UVs[0] = new Vector2(0, 0);
        UVs[1] = new Vector2(-.5f, 1);
        UVs[2] = new Vector2(1.5f, 1);
        UVs[3] = new Vector2(1, 0);
        UVs[4] = new Vector2(.5f, 2);

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

    //void OnDrawGizmos()
    //{
    //    var filter = GetComponent<MeshFilter>();

    //    //for each vertex in the mesh
    //    foreach (Vector3 vertex in customMesh.vertices)
    //    {
    //        //draw a sphere on at vertex position
    //        Gizmos.color = Color.green;
    //        Vector3 worldPos = transform.TransformPoint(vertex);
    //        Gizmos.DrawSphere(worldPos, radius);
    //    }


    //}
}
