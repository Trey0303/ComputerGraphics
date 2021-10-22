using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            //Debug.Log("picked up item");
            if (gameObject.tag == "Orange")
            {
                Debug.Log("Orange");
                Destroy(gameObject);
            }
            if (gameObject.tag == "Green")
            {
                Debug.Log("Green");
                Destroy(gameObject);
            }
            if (gameObject.tag == "Purple")
            {
                Debug.Log("Purple");
                Destroy(gameObject);
            }
        }
        
    }
}
