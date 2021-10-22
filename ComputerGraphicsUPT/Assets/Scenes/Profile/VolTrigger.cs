using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolTrigger : MonoBehaviour
{

    //on triggerenter set to expected profile volumes
    //disable any currently applied profile volume filters

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            //Debug.Log("picked up item");
            if (gameObject.tag == "Bloom")
            {
                Debug.Log("Bloom");
                Destroy(gameObject);
            }
            if (gameObject.tag == "MotionBlur")
            {
                Debug.Log("MotionBlur");
                Destroy(gameObject);
            }
            if (gameObject.tag == "DepthOfField")
            {
                Debug.Log("DepthOfField");
                Destroy(gameObject);
            }
        }

    }
}
