using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


//to get a camera to work with triggers you need a rigidbody and collider component attached to the camera
public class VolTrigger : MonoBehaviour
{
    public Volume vol;
    public Health health;
    private bool critical;

    //on triggerenter set to expected profile volumes
    //disable any currently applied profile volume filters

    private void Start()
    {
        vol = this.GetComponent<Volume>();
        critical = false;
    }

    private void Update()
    {
        //if health is in critical range
        if (health.curHealth == 1)
        {
            if (!critical)
            {
                if (vol.profile.TryGet<Vignette>(out var vignette))
                {
                    vignette.active = true;
                    critical = true;
                }

            }
        }
        //if player health is outside of critical health range or if player is dead
        if (health.curHealth > 1 || health.curHealth <= .01)
        {
            if (critical)
            {
                if (vol.profile.TryGet<Vignette>(out var vignette))
                {
                    vignette.active = false;
                    critical = false;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider volTrigger)
    {
        if (volTrigger.tag == "Bloom")
        {
            if (vol.profile.TryGet<Bloom>(out var bloom))
            {
                bloom.active = true;
            }

        }
        if (volTrigger.tag == "MotionBlur")
        {
            if (vol.profile.TryGet<MotionBlur>(out var motionBlur))
            {
                motionBlur.active = true;
            }
        }
        if (volTrigger.tag == "DepthOfField")
        {
            if (vol.profile.TryGet<DepthOfField>(out var depthOfField))
            {
                depthOfField.active = true;
            }
        }

    }

    private void OnTriggerExit(Collider volTrigger)
    {
        if (volTrigger.tag == "Bloom")
        {
            if (vol.profile.TryGet<Bloom>(out var bloom))
            {
                bloom.active = false;
            }

        }
        if (volTrigger.tag == "MotionBlur")
        {
            if (vol.profile.TryGet<MotionBlur>(out var motionBlur))
            {
                motionBlur.active = false;
            }
        }
        if (volTrigger.tag == "DepthOfField")
        {
            if (vol.profile.TryGet<DepthOfField>(out var depthOfField))
            {
                depthOfField.active = false;
            }
        }
    }
}
