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
        Debug.Log("Data.OrangeItemCount " + Data.OrangeItemCount);
        Debug.Log("Data.MaxOrange " + Data.MaxOrange);
        Debug.Log("Data.PurpleItemCount " + Data.PurpleItemCount);
        Debug.Log("Data.MaxPurple " + Data.MaxPurple);

        //finished/complete versions on end screen depending on player collecting everything or not
        if (Data.OrangeItemCount == Data.MaxOrange && Data.PurpleItemCount == Data.MaxPurple)
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
            SceneManager.LoadScene(0);
        }
    }
}
