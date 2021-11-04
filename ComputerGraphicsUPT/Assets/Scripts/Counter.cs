using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    
    public Text mytext;
    public Transform textpos;
    public int count;
    public float gridWidth;
    private float gridHeight;

    // Start is called before the first frame update
    void Start()
    {
        //mytext.text = "0";
        count = 0;
        mytext = GetComponent<Text>();
        //gridWidth = mytext.GetComponent<RectTransform>().sizeDelta.x;
        //gridHeight = mytext.GetComponent<RectTransform>().sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        //mytext.text = "" + count;
    }

    private void OnGUI()
    {
        //Unity execute the method, and draws in every
        //frame a label (transparent, of curse)
        //positioned in x=1 Y=1 with height=30 and width=200,
        //and prints the value stored
        //in butterflyCounter);
        //GUI.Label(new Rect(this.transform.position.x, this.transform.position.y, gridWidth, gridHeight), "Butterflies: " + count);
    }
}
