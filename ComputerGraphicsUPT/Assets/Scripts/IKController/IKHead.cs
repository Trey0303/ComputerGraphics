using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHead : MonoBehaviour
{
    protected Animator animator;

    public bool ikActive = false;
    public Transform lookObj = null;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {
            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {

                // Set the look target position, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }
                 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("in range");
        if(other.gameObject.tag == "Look")
        {
            lookObj = other.transform.GetChild(0);
            ikActive = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Look")
        {
            lookObj = null;
            ikActive = false;

        }
    }
}
