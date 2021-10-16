using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRange : MonoBehaviour
{
    public IKControl ikGrab;

    public bool inRange;
    private float count;
    private float timer;
    private bool startTimer;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        timer = 0;
    }

    void Update()
    {
        
            
        

        //ObjectGrabRange(transform.position, 1);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inRange)
            {
                Debug.Log("Grab");
                //grab = true;
                ikGrab.ikActive = true;
                startTimer = true;

            }
            
        }

        if (startTimer)
        {
            count += Time.deltaTime;
            timer = Mathf.FloorToInt(count % 60);
            //Debug.Log(timer);
            if (count >= .3)
            {

                Destroy(gameObject);
                startTimer = false;
                ikGrab.ikActive = false;
                this.enabled = false;
            }

        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("In grabbing range");
            inRange = true;
        

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;

        }
    }

}

