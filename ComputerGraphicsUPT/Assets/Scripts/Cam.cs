using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject target;
    public float distanceX = 1;
    public float distanceY = 1;
    public float distanceZ = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x + distanceX, target.transform.position.y + distanceY, target.transform.position.z - distanceZ);
    }
}
