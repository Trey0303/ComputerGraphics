using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class pauseMenuColor : MonoBehaviour
{
    public GameObject player;
    public SamplePlayerCharacter playerScript;

    public Volume vol;
    public Health health;
    private bool critical;

    //on triggerenter set to expected profile volumes
    //disable any currently applied profile volume filters

    private void Start()
    {
        vol = this.GetComponent<Volume>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<SamplePlayerCharacter>();

    }

    private void Update()
    {
        //if (!playerScript.uiActive)
        //{
        //    if (vol.profile.TryGet<Vignette>(out var vignette))
        //    {
        //        vignette.active = true;
        //    }

        //}
    }
}
