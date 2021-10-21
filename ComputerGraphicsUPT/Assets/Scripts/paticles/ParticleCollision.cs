using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Health health;
    private bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            
            //Debug.Log("player takes damage");
            
            health.TakeDamage(1);

        }
    }
}
