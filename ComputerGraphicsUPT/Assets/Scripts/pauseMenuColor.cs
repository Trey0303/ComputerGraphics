using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class pauseMenuColor : MonoBehaviour
{
    public GameObject player;
    public SamplePlayerCharacter playerScript;

    public GameObject ui;

    public Volume vol;
    //public Health health;
    private bool critical;

    public ColorParameter vignetteColor;

    public ColorParameter vignetteColorOriginal;
    //public Vignette vignette;

    //on triggerenter set to expected profile volumes
    //disable any currently applied profile volume filters

    private void Start()
    {
        vol = this.GetComponent<Volume>();
        //get player gameObject and player controller script
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<SamplePlayerCharacter>();

        vignetteColor.value = Color.blue;
        if (vol.profile.TryGet<Vignette>(out var vignette))
        {
            //vignetteColorOriginal = vignette.color.value;
            
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
            if (vol.profile.TryGet<Vignette>(out var vignette))
            {
                //vignette.color = 
                vignette.active = true;
                vignette.color.value = vignetteColor.value;
                vignette.intensity.value = 7f;
            }

        }
        if (!playerScript.uiActive)
        {
            if (vol.profile.TryGet<Vignette>(out var vignette))
            {
                vignette.active = false;
            }
        }
    }
}
