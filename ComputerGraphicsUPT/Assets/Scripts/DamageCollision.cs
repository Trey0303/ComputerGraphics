using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    public Health health;


//note: have to enable contact pairs for kinematic to static in project settings
//      (edit > project settings > physics > contact pairs mode)
    private void OnCollisionEnter(Collision other)
    {
            Debug.Log("touched spikes");
        if (other.gameObject.tag == "Player")
        {

            //Debug.Log("player takes damage");
            health.TakeDamage(1);

        }
    }
}
