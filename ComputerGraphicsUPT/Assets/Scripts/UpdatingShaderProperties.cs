using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatingShaderProperties : MonoBehaviour
{
    private Renderer rend;
    private Shader shader;
    //public string tintOriginProperty;
    public Vector4 tintOrigin;

    public GameObject target;

    public Vector3 targetPos;

    public float w = 0;

    //public string tintRadiusProperty;
    public float tintRadius = 1;


    void Start()
    {
        rend = GetComponent<Renderer>();

        //rend.material.shader = Shader.Find("NewShaderGraph");

        if(rend != null)
        {
            shader = rend.material.shader;

        }

        if(target != null)
        {
            targetPos = target.transform.position;
            tintOrigin = new Vector4(targetPos.x, targetPos.y, targetPos.z, w);

        }

    }

    void Update()
    {
        if(target != null)
        {
            if (targetPos != target.transform.position)
            {
                targetPos = target.transform.position;
                tintOrigin = new Vector4(targetPos.x, targetPos.y, targetPos.z, w);
            }

        }
        //rend.material.SetVector("_TargetPosition", tintOrigin);
        //rend.material.SetFloat("_Radius", tintRadius);

        Shader.SetGlobalVector("_TargetPosition", tintOrigin);
        Shader.SetGlobalFloat("_Radius", tintRadius);
    }

    void OnDrawGizmos()
    {
        if (rend != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(Shader.GetGlobalVector("_TargetPosition"), Shader.GetGlobalFloat("_Radius"));

        }
    }
}
