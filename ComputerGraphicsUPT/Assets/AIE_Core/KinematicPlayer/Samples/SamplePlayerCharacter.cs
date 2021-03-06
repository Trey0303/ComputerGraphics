using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Sample character script demonstrating how to send inputs to a motor
/// </summary>
public class SamplePlayerCharacter : MonoBehaviour
{
    public ParticleSystem system;

    public GameObject ui;

    public ActiveUI activeUI;

    // The motor we're controlling
    public KinematicPlayerMotor motor;

    public Animator anims;

    public Rigidbody rb;

    public float maxTurnRate = 8;

    public bool dance = false;

    public bool uiActive = false;

    [Obsolete]
    void Start()
    {

        if (ui != null)
        {
            ui.SetActive(uiActive);

        }

        if(system != null)
        {
            system.enableEmission = false;

        }


    }

    private void Update()
    {

        // send inputs to motor
        if (uiActive == false)////If game NOT Paused
        {
            motor.MoveInput(new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")));

        }

        //this is not needed if you want backwards/strafing animations
        if (new Vector3(motor.body.Velocity.x, 0.0f, motor.body.Velocity.z) != Vector3.zero)//this if statements prevents unnessessary rotation
        {
            rb.rotation = Quaternion.LookRotation(new Vector3(motor.body.Velocity.x, 0.0f, motor.body.Velocity.z) * maxTurnRate);

        }

        Vector3 localVel = transform.InverseTransformVector(motor.body.Velocity);

        float localVelY = 0;

        //strafe
        float localVelX = localVel.x;
        //forward/-forward
        float localVelZ = localVel.z;

        Vector3 localDirection = new Vector3(localVelX, localVelY, localVelZ);

        //Debug.Log("X: " + localDirection.x);
        //Debug.Log("Y: " + localDirection.y);
        //Debug.Log("Z: " + localDirection.z);

        //Debug.Log(localVel);

        //player controls
        if (uiActive == false)//If game NOT Paused
        {
            if (Input.GetButtonDown("Jump"))
            {
                motor.JumpInput();

                if (motor.Grounded)
                {
                    //emit jump particles
                    ParticleControl jumpParticles = GetComponent<ParticleControl>();
                    //                       color,size,number
                    jumpParticles.DoEmit(Color.blue, 1f, 5);

                }

            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                if (dance)
                {
                    dance = false;
                    //Debug.Log("NOT dancing");
                }
                else if (!dance)
                {
                    dance = true;
                    //Debug.Log("dancing");
                }
            }
        }

        //pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiActive = !uiActive;
            ui.SetActive(uiActive);

            if (uiActive == false)//resumeGame
            {
                Time.timeScale = 1;
                activeUI.show = true;
            }
            else//pauseGame
            {
                Time.timeScale = 0;
                activeUI.hide = true;
            }
        }

        if (anims != null)
        {

            anims.SetBool("Grounded", motor.Grounded);
            anims.SetFloat("Speed", motor.speed);
            anims.SetFloat("LocalVelX", localDirection.x);
            anims.SetFloat("LocalVelZ", localDirection.z);
            anims.SetBool("Dance", dance);
            //anims.SetBool("Swimming", Data.IsSwimming);


        }
    }
}
