using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    //public Counter counter;
    public Text complete;
    public Text finished;

    private void Start()
    {
        //need to get values from counter script
        //Debug.Log("Data.OrangeItemCount " + Data.OrangeItemCount);
        //Debug.Log("Data.MaxOrange " + Data.MaxOrange);
        //Debug.Log("Data.PurpleItemCount " + Data.PurpleItemCount);
        //Debug.Log("Data.MaxPurple " + Data.MaxPurple);

        //finished/complete versions on end screen depending on player collecting everything or not
        if(complete != null && finished != null)
        {
            if (StoreData.OrangeItemCount == StoreData.MaxOrange && StoreData.PurpleItemCount == StoreData.MaxPurple)
            {
                //if all orange and purple items collected display Complete
                complete.enabled = true;
                finished.enabled = false;
            }
            else//if player did NOT collect all orange and purple items then display Finished
            {
                finished.enabled = true;
                complete.enabled = false;
            }

        }
    }
    
    
    //replay option using enter key
    //reset to first scene

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Return))//Enter Key(NOT num Enter)
        {
            StoreData.OrangeItemCount = 0;
            StoreData.PurpleItemCount = 0;
            StoreData.GreenItemCount = 0;
            StoreData.OrangeComplete = false;
            StoreData.PurpleComplete = false;
            SceneManager.LoadScene(1);
        }
    }
}
