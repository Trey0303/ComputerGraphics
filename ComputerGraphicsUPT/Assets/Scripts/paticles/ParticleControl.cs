using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    //ParticleSystem ps;

    SamplePlayerCharacter player;

    //public float startDelay = 5f;
    //public float startLifeTime = 2f;

    //[Header("Emission")]
    //public float rateOverTime = 1;
    //public float rateOverDistance = 1;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SamplePlayerCharacter>();
        //    ps = GetComponent<ParticleSystem>();

        //    //obtain reference to Main module
        //    ParticleSystem.MainModule main = ps.main;

        //    //adjust properties
        //    main.startDelay = startDelay;
        //    main.startLifetime = startLifeTime;

        //    // no need to write the module back into the Particle System - the
        //    // changes are already applied
    }

    public void DoEmit(Color color, float startSize, int particleCount)
    {
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        var shapeParams = player.system.shape;
        shapeParams.rotation = new Vector3(90, 0, 0);
        emitParams.startColor = color;
        emitParams.startSize = startSize;
        player.system.Emit(emitParams, particleCount);
    }
}
