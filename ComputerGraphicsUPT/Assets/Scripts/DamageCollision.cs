using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    public Health health;


//note: have to enable contact pairs for kinematic to static in project settings
//      (edit > project settings > physics > contact pairs mode)

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            health.TakeDamage(1);
             
        }
    }
}
