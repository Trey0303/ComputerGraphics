using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Health health;

    float maxHealth;

    //active ingame
    public Text orangeText;
    public int orangeCount;

    public Text greenText;
    public int greenCount;

    public Text purpleText;
    public int purpleCount;


    //paused game
    public Text orangeTextPaused;

   //// public Text greenTextPaused;

    public Text purpleTextPaused;


    // Start is called before the first frame update
    void Start()
    {
        StoreData.MaxOrange = 52;
        StoreData.MaxPurple = 3;
        StoreData.MaxGreen = 10;

        maxHealth = health.curHealth;

        orangeText.text = "" + StoreData.OrangeItemCount;
        greenText.text = "" + StoreData.GreenItemCount;
        purpleText.text = "" + StoreData.PurpleItemCount;

        orangeTextPaused.text = "" + StoreData.OrangeItemCount + " / " + StoreData.MaxOrange;
        purpleTextPaused.text = "" + StoreData.PurpleItemCount + " / " + StoreData.MaxPurple;

    }

    // Update is called once per frame
    void Update()
    {
        orangeText.text = "" + StoreData.OrangeItemCount;
        greenText.text = "" + StoreData.GreenItemCount;
        purpleText.text = "" + StoreData.PurpleItemCount;

        orangeTextPaused.text = "" + StoreData.OrangeItemCount + " / " + StoreData.MaxOrange;
        purpleTextPaused.text = "" + StoreData.PurpleItemCount + " / " + StoreData.MaxPurple;

        //when player has less than max health
        if (health.curHealth < maxHealth)
        {
            //and player has enough green
            if (StoreData.GreenItemCount == StoreData.MaxGreen)
            {
                //heal player by 1
                health.Heal(1);

                greenCount = StoreData.GreenItemCount;
            }

        }
        
    }

}
