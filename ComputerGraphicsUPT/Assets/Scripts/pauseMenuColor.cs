using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class pauseMenuColor : MonoBehaviour
{
    VolTrigger volTrigger;

    public GameObject player;
    public SamplePlayerCharacter playerScript;

    public GameObject ui;

   // public Volume vol;
    //public Health health;
    private bool critical;

    public Color vignettePauseColor;

    public Color vignetteColorOriginal;
    public float originalIntensity;

    //public Vignette vignette;

    //on triggerenter set to expected profile volumes
    //disable any currently applied profile volume filters

    private void Start()
    {
        volTrigger = gameObject.GetComponent<VolTrigger>();
        //vol = this.GetComponent<Volume>();
        //get player gameObject and player controller script
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<SamplePlayerCharacter>();

        vignettePauseColor = Color.blue;
        if (volTrigger.vol.profile.TryGet<Vignette>(out var vignette))
        {
            vignetteColorOriginal = vignette.color.value;
            originalIntensity = vignette.intensity.value;
        }

        //get ui gameObject and player health script
        //ui = GameObject.FindGameObjectWithTag("UI");
        //health = ui.GetComponent<Health>();

        //health.TakeDamage(1);

    }

    private void Update()
    {
        if (playerScript.uiActive)
        {
            if (volTrigger.vol.profile.TryGet<Vignette>(out var vignette))
            {
                //vignette.color = 
                vignette.active = true;
                vignette.color.value = vignettePauseColor;
                vignette.intensity.value = 7f;
            }

        }
        if (!playerScript.uiActive)
        {
            if (volTrigger.vol.profile.TryGet<Vignette>(out var vignette))
            {
                vignette.color.value = vignetteColorOriginal;
                vignette.intensity.value = originalIntensity;

                //if player is dead or healthy
                if (volTrigger.health.curHealth > 1 || volTrigger.health.curHealth <= .01)
                {
                    vignette.active = false;
                }
            }
        }
    }
}
