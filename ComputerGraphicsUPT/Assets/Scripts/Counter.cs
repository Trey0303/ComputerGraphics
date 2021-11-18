using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    //active ingame
    public Text orangeText;
    public int orangeCount;
    public int maxOrange = 51;

    public Text greenText;
    public int greenCount;

    public Text purpleText;
    public int purpleCount;
    public int maxPurple = 3;


    //paused game
    public Text orangeTextPaused;

   // public Text greenTextPaused;

    public Text purpleTextPaused;


    // Start is called before the first frame update
    void Start()
    {
        Data.MaxOrange = maxOrange;
        Data.MaxPurple = maxPurple;

        //mytext.text = "0";
        orangeCount = 0;
        greenCount = 0;
        purpleCount = 0;

        orangeText.text = "" + orangeCount;
        greenText.text = "" + greenCount;
        purpleText.text = "" + purpleCount;

        orangeTextPaused.text = "" + orangeCount + " / " + maxOrange;
       // greenTextPaused.text = "" + greenCount;
        purpleTextPaused.text = "" + purpleCount;

        //gridWidth = mytext.GetComponent<RectTransform>().sizeDelta.x;
        //gridHeight = mytext.GetComponent<RectTransform>().sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        orangeText.text = "" + orangeCount;
        greenText.text = "" + greenCount;
        purpleText.text = "" + purpleCount;

        orangeTextPaused.text = "" + orangeCount + " / " + maxOrange;
        //greenTextPaused.text = "" + greenCount;
        purpleTextPaused.text = "" + purpleCount + " / " + maxPurple;
    }

}
