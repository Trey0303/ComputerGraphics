using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Health health;


    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            
            //Debug.Log("player takes damage");
            
            health.TakeDamage(1);

        }
    }
}
