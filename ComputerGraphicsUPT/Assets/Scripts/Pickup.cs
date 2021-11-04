using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Counter countitem;

    private void Start()
    {
        //countitem = GameObject.GetComponent("Counter");
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            //Debug.Log("picked up item");
            if (gameObject.tag == "Orange")
            {
                Debug.Log("Orange");
                countitem.count++;
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
