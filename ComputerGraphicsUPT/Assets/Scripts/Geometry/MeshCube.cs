using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCube : MonoBehaviour
{
    private Mesh customMesh;

    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        // Vertices
        // locations of vertices
        Vector3[] verts = new Vector3[8];

        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(0, 1, 0);
        verts[2] = new Vector3(1, 0, 0);
        verts[3] = new Vector3(1, 1, 0);
        verts[4] = new Vector3(1,1,1);
        verts[5] = new Vector3(0,1,1);
        verts[6] = new Vector3(1,0,1);
        verts[7] = new Vector3(0,0,1);

        mesh.vertices = verts;

        //Triangles
        /*Next, you need to set up the triangles. A quad consists of two triangles, each made up of three points in the vertex array you created earlier. 
         * To specify the points, you define each triangle as three indices of the the vertex array. For example, 
         * the lower left triangle for this quad uses index 0, 2, and 1 which corresponds to coordinates (0, 0, 0), (0, height, 0), and (width, 0, 0) from the vertex array. 
         * The ordering is important because you must order the corners clockwise. The upper right triangle uses index 2, 3, and 1.*/
        int[] indices = new int[36];

        //front
        indices[0] = 0;
        indices[1] = 1;
        indices[2] = 2;
        
        indices[3] = 2;
        indices[4] = 1;
        indices[5] = 3;

        //top
        indices[6] = 4;
        indices[7] = 3;
        indices[8] = 1;

        indices[9] = 1;
        indices[10] = 5;
        indices[11] = 4;

        //bottom
        indices[12] = 7;
        indices[13] = 0;
        indices[14] = 2;

        indices[15] = 6;
        indices[16] = 7;
        indices[17] = 2;

        //left
        indices[18] = 2;
        indices[19] = 3;
        indices[20] = 4;

        indices[21] = 2;
        indices[22] = 4;
        indices[23] = 6;

        //right
        indices[24] = 1;
        indices[25] = 0;
        indices[26] = 7;

        indices[27] = 5;
        indices[28] = 1;
        indices[29] = 7;

        //back
        indices[30] = 4;
        indices[31] = 5;
        indices[32] = 6;

        indices[33] = 7;
        indices[34] = 6;
        indices[35] = 5;

        mesh.triangles = indices;

        // Normals
        // describes how light bounces off the surface (at the vertex level)
        //
        // note that this data is interpolated across the surface of the triangle
        Vector3[] norms = new Vector3[8];

        norms[0] = Vector3.forward;
        norms[1] = Vector3.forward;
        norms[2] = Vector3.forward;
        norms[3] = Vector3.forward;
        norms[4] = Vector3.forward;
        norms[5] = Vector3.forward;
        norms[6] = Vector3.forward;
        norms[7] = Vector3.forward;

        mesh.normals = norms;

        //texture cordinates
        // UVs, STs
        // defines how textures are mapped onto the surface
        Vector2[] UVs = new Vector2[8];

        //UVs[0] = new Vector3(0, 0);
        //UVs[1] = new Vector3(0, 1);
        //UVs[2] = new Vector3(1, 0);
        //UVs[3] = new Vector3(1, 1);
        UVs[0] = new Vector2(0, 0);
        UVs[1] = new Vector2(0, 1);
        UVs[2] = new Vector2(1, 0);
        UVs[3] = new Vector2(1, 1);
        UVs[4] = new Vector2(1, 1);
        UVs[5] = new Vector2(0, 1);
        UVs[6] = new Vector2(1, 0);
        UVs[7] = new Vector2(0, 0);

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
