using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FadeToBlack : MonoBehaviour
{
    public Volume vol;
    private bool startFade;
    private float fadeSpeed;
    private bool fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        vol = this.GetComponent<Volume>();

        startFade = false;
        fadeOut = false;
        fadeSpeed = 7;

        if (vol.profile.TryGet<ColorAdjustments>(out var adj))
        {
            adj.postExposure.value = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //fade
        if (Input.GetKeyDown(KeyCode.F))
        {
            startFade = true;
        }
        if (startFade)
        {
            StartCoroutine(Fade());
        }


    }

    IEnumerator Fade()
    {
        if (vol.profile.TryGet<ColorAdjustments>(out var adj))
        {
            if (!fadeOut)
            {
                FadeIn();

            }
            yield return new WaitForSeconds(1);
            
            if (fadeOut)
            {
                FadeOut();
                
            }
        }
    }

    void FadeIn()
    {
        if (vol.profile.TryGet<ColorAdjustments>(out var adj))
        {

            adj.postExposure.value -= Time.deltaTime * fadeSpeed;

            if (adj.postExposure.value <= -13f)
            {
                fadeOut = true;
            }
        }
    }
    private void FadeOut()
    {
        if (vol.profile.TryGet<ColorAdjustments>(out var adj))
        {
            adj.postExposure.value += Time.deltaTime * fadeSpeed;

            if (adj.postExposure.value > 0)
            {
                adj.postExposure.value = 0;
                startFade = false;
                fadeOut = false;
            }
        }
    }
}
