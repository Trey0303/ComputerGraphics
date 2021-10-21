using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//set the particale particles systems to 'world' simulation space to get it to move towards the direction you want the particales to move to
public class ParticlePointAttractor : MonoBehaviour
{
    public ParticleSystem parSystem;
    public ParticleSystem.Particle[] particles;
    public Transform target;

    

    public float strength = 1;
    public float radius = 1;

    // Start is called before the first frame update
    void Start()
    {
        particles = new ParticleSystem.Particle[parSystem.maxParticles];
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target.position, parSystem.transform.position);
        //if in radius
        if (distance < radius)
        {
            int numParticles = parSystem.GetParticles(particles);
            for (int i = 0; i < numParticles; i++)
            {
                //Debug.Log(particles[i].position);
                //Debug.Log("Particle: " + i);

                distance = Vector3.Distance(target.position, parSystem.transform.position);

                //Debug.Log("in range");
                //move particles towards target
                if (distance > 0.1f)
                {
                    Debug.DrawLine(parSystem.transform.position, target.position, Color.white);
                    //Debug.Log("Move");
                    particles[i].position = Vector3.MoveTowards(particles[i].position, target.position, strength * Time.deltaTime);

                }

            }
            parSystem.SetParticles(particles, numParticles);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(radius, radius, radius));
    }
}
