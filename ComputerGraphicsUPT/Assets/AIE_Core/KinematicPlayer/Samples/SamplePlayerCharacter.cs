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
        
        //this is not needed if you want backwards/strafing animations
        //rb.rotation = Quaternion.LookRotation(new Vector3(motor.body.Velocity.x, 0.0f, motor.body.Velocity.z) * maxTurnRate);

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

        //motor.body.Velocity.x = transform.Rotate(new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f) * maxTurnRate);
        //motor.body.Velocity.z = transform.Rotate(new Vector3(0.0f, 0.0f, Input.GetAxisRaw("Vertical")) * maxTurnRate);

        //Debug.Log(localVel);

        if (Input.GetButtonDown("Jump"))
        {
            motor.JumpInput();
        }

        anims.SetBool("Grounded", motor.Grounded);
        anims.SetFloat("Speed", motor.speed);
        anims.SetFloat("LocalVelX", localDirection.x);
        anims.SetFloat("LocalVelZ", localDirection.z);

    }
}
