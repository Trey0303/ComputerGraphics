using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public GameObject[] panels;
    public Button[] buttons;
    //int[] arPanels;
    //int panel;
    //int curTab = 0;
    int lastTab = 0;
    //int buttonIndex = 0;

    private void Start()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            Button btn = buttons[i].GetComponent<Button>();
            //buttonIndex = i;
            //Debug.Log("Button selected: " + buttonIndex);


            int buttonNumber = i;
            btn.onClick.AddListener(
                () =>
                {
                    //Debug.Log(buttonNumber);
                    ShowTab(buttonNumber);
                    
                }
                );
        }
        
    }

    void ShowTab(int tabIndex)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            //Debug.Log("i: " + i);
            //Debug.Log("tabIndex: " + tabIndex);
            if (i == tabIndex)
            {
                try
                {
                    //Hides the previously shown tab, if any
                    HideTab();

                    //Shows the tab at the given index
                    show(i);

                    //update last opened Tab
                    lastTab = i;
                    //Debug.Log("lastTab: " + lastTab);
                }
                //If the index is out of bounds, throw an IndexOutOfRangeException
                catch(IndexOutOfRangeException ex)
                {
                    throw new ArgumentException("Index is out of range ", nameof(tabIndex), ex);
                }

            }

        }
    }

    private void show(int tabIndex)
    {
        panels[tabIndex].SetActive(true);
    }

    void HideTab()
    {
        if (lastTab != null)
        {
            panels[lastTab].SetActive(false);

        }
    }

    RectTransform CurrentTab{get; }

    RectTransform[] Tabs { get; }


}

