using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeProceduralGeneration : MonoBehaviour
{
    public int numSegments;
    public int numFaces;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        ////Double Loop: used to create the positions and normals
        DoubleLoop();
        
        //Vector3[] verts = new Vector3[numSegments * numFaces];
        //Vector3[] normal = new Vector3[numSegments * numFaces];
        ////get the increment per face around the tube in radians
        //float deltaPhi = Mathf.PI * 2.0f / numFaces;
        //DoubleLoop();

        ////UV coordinates and index buffer
        
        //Vector2[] uvs = new Vector2[numSegments * numFaces];
        //int k = 0;
        //UVDoubleLoop();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DoubleLoop()
    {
        Vector3[] verts = new Vector3[numSegments * numFaces]; 
        Vector3[] normal = new Vector3[numSegments * numFaces];// get the increment per face around the tube in radians
        float deltaPhi = Mathf.PI * 2.0f / numFaces;
        for(int i = 0; i < numSegments; i++){
            for(int j = 0; j < numFaces; j++){
                int index = i * numFaces + j;
                float phi = j * deltaPhi;
                normal[index] = Vector3.right * Mathf.Cos(phi) + Vector3.forward * Mathf.Sin(phi);
                Vector3 centre = i * Vector3.up;
                verts[index] = centre + normal[index] * radius;
            }
        }
    }

    void UVDoubleLoop()
    {
        for(int i = 0; i < numSegments; i++)
        {
            for(int j = 0; j < numFaces; j++)
            {

            }
        }
    }
}
