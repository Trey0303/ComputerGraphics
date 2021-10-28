using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialVisualDebug : MonoBehaviour
{

    public float radius = 1.0f;

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
