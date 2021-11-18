using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject ui;
    public Counter countItem;


    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UICounter");
        countItem = ui.GetComponent<Counter>();
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            //Debug.Log("picked up item");
            if (gameObject.tag == "Orange")
            {
                //Debug.Log("Orange");
                countItem.orangeCount++;
                Data.OrangeItemCount = countItem.orangeCount;
                
                Destroy(gameObject);
            }
            if (gameObject.tag == "Green")
            {
                //Debug.Log("Green");
                countItem.greenCount++;
                Data.GreenItemCount = countItem.greenCount;

                Destroy(gameObject);
            }
            if (gameObject.tag == "Purple")
            {
                //Debug.Log("Purple");
                countItem.purpleCount++;
                Data.PurpleItemCount = countItem.purpleCount;

                Destroy(gameObject);
            }
        }
        
    }
}
