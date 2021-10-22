using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FadeToBlack : MonoBehaviour
{
    public Volume vol;

    //Color color;

    //Vignette vignetteTemp;

    //public Volume volTemp;

    public ColorParameter colorTemp;
    public ColorParameter colorOriginal;

    // Start is called before the first frame update
    void Start()
    {
        vol = this.GetComponent<Volume>();
        //volTemp = new Volume();

        colorTemp.value = new Color(0f, 0f, 0f);

        if (vol.profile.TryGet<Vignette>(out var vignette))
        {
            vignette.active = false;
            colorOriginal = vignette.color;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //fade
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Fade());
            
        }
    }

    IEnumerator Fade()
    {
        if (vol.profile.TryGet<Vignette>(out var vignette))
        {
            vignette.active = true;
            vignette.color = colorTemp;
            yield return new WaitForSeconds(1);
            vignette.color = colorOriginal;
        }
    }
}
