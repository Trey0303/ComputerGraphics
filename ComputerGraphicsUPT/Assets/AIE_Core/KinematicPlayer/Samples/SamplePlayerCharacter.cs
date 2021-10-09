using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sample character script demonstrating how to send inputs to a motor
/// </summary>
public class SamplePlayerCharacter : MonoBehaviour
{
    // The motor we're controlling
    public KinematicPlayerMotor motor;

    public Animator anims;

    public Rigidbody rb;

    //public float speed = 0;
    //public float maxSpeed = 2;

    public float maxTurnRate = 8;

    private void Update()
    {
        // send inputs to motor
        motor.MoveInput(new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")));
        
        rb.rotation = Quaternion.LookRotation(-new Vector3(motor.body.Velocity.x, 0.0f, motor.body.Velocity.z) * maxTurnRate);

        Vector3 localVel = transform.TransformDirection(motor.body.Velocity);

        float localVelX = localVel.x;
        float localVelZ = localVel.z;

        
        Debug.Log(localVelX);
        Debug.Log(localVelZ);

        //motor.body.Velocity.x = transform.Rotate(new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f) * maxTurnRate);
        //motor.body.Velocity.z = transform.Rotate(new Vector3(0.0f, 0.0f, Input.GetAxisRaw("Vertical")) * maxTurnRate);

        //Debug.Log(localVel);

        if (Input.GetButtonDown("Jump"))
        {
            motor.JumpInput();
        }

        anims.SetBool("Grounded", motor.Grounded);
        anims.SetFloat("Speed", motor.speed);
        anims.SetFloat("LocalVelX", localVelX);
        anims.SetFloat("LocalVelZ", localVelZ);

    }
}
