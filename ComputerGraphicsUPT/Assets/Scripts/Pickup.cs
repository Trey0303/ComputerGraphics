using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject ui;
    public Counter countItem;
    //public ActiveUI activeUI;


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
                //countItem.orangeCount++;
                StoreData.OrangeItemCount++;
                StoreData.ShowOrange = true;
                StoreData.OrangeTimer = 1;

                Destroy(gameObject);
            }
            if (gameObject.tag == "Green")
            {
                //Debug.Log("Green");
                if(StoreData.GreenItemCount < StoreData.MaxGreen)
                {
                    //countItem.greenCount++;
                    StoreData.GreenItemCount++;

                }

                Destroy(gameObject);
            }
            if (gameObject.tag == "Purple")
            {
                //Debug.Log("Purple");
                //countItem.purpleCount++;
                StoreData.PurpleItemCount++;
                StoreData.ShowPurple = true;
                StoreData.PurpleTimer = 1;

                Destroy(gameObject);
            }
        }
        
    }
}
