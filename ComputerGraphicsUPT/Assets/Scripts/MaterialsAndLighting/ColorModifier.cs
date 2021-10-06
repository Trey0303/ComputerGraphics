using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorModifier : MonoBehaviour
{
    MeshRenderer mesh;


    public Color _color;

    //public float a;

    public Texture mainTexture, normal, metal;

    private float decrement = .5f;

    bool fade = false;


    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        //color
        //mesh.material.EnableKeyword("_BASECOLOR");
        //a = _color.a;
        //Debug.Log(a);
        mesh.material.SetColor("_BaseColor", _color);
        Debug.Log(_color.a);

        //texture
        //mesh.material.EnableKeyword("_MAINTEX");
        mesh.material.EnableKeyword("_NORMALMAP");
        mesh.material.EnableKeyword("_METALLICGLOSSMAP");

        mesh.material.SetTexture("_BaseMap", mainTexture);
        mesh.material.SetTexture("_BumpMap", normal);
        mesh.material.SetTexture("_MetallicGlossMap", metal);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            fade = true;
            
        }

        if (fade)
        {
            _color.a -= decrement * Time.deltaTime;
            mesh.material.SetColor("_BaseColor", _color);
        }
    }
}
