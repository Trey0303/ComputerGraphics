using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveUI : MonoBehaviour
{
    public GameObject[] activeUI;
    public GameObject collectableOrangeUI;
    public GameObject collectablePurpleUI;

    public GameObject OrangeCompleteUI;
    public GameObject PurpleCompleteUI;

    public bool hide = false;
    public bool show = false;
    public bool canPauseExit = false;

    public bool showOrange = false;
    public bool showPurple = false;
    public float orangeTimer = 0;
    public float purpleTimer = 0;
    private bool purpleComplete = false;
    private bool orangeComplete = false;

    //public float time = 3;

    // Start is called before the first frame update
    void Start()
    {
        StoreData.OrangeComplete = orangeComplete;
        StoreData.PurpleComplete = purpleComplete;
        //Data.Timer = time;
        StoreData.ShowOrange = showOrange;
        StoreData.ShowPurple = showPurple;

        show = false;
        hide = false;
        for (int i = 0; i < activeUI.Length; i++)
        {
            activeUI[i].SetActive(true);
             
        }
        //hide orange and purple at the start
        collectableOrangeUI.SetActive(false);
        collectablePurpleUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            for (int i = 0; i < activeUI.Length; i++)
            {
                activeUI[i].SetActive(true);

            }
            show = false;
        }
        if (hide)
        {
            for (int i = 0; i < activeUI.Length; i++)
            {
                activeUI[i].SetActive(false);

            }
            hide = false;
        }
        if (StoreData.ShowOrange)
        {
            OrangeDisplay();
        }
        if (StoreData.ShowPurple)
        {
            PurpleDisplay();
        }
        if (!orangeComplete)
        {
            if (StoreData.OrangeItemCount == StoreData.MaxOrange)
            {
                StartCoroutine(OrangeComplete());

            }
        }
        if (!purpleComplete)
        {
            if (StoreData.PurpleItemCount == StoreData.MaxPurple)
            {
                StartCoroutine(PurpleComplete());

            }
        }

        
        
    }

    void OrangeDisplay()
    {
        collectableOrangeUI.SetActive(true);
        StoreData.OrangeTimer -= Time.deltaTime;
        if (StoreData.OrangeTimer <= 0)
        {
            collectableOrangeUI.SetActive(false);
            StoreData.ShowOrange = false;
        }
    }

    void PurpleDisplay()
    {
        collectablePurpleUI.SetActive(true);
        StoreData.PurpleTimer -= Time.deltaTime;
        if (StoreData.PurpleTimer <= 0)
        {
            collectablePurpleUI.SetActive(false);
            StoreData.ShowPurple = false;
        }
    }

    IEnumerator OrangeComplete()
    {
        OrangeCompleteUI.SetActive(true);

        yield return new WaitForSeconds(2);

        OrangeCompleteUI.SetActive(false);
        orangeComplete = true;
        StoreData.OrangeComplete = orangeComplete;
        

    }
    IEnumerator PurpleComplete()
    {
        PurpleCompleteUI.SetActive(true);

        yield return new WaitForSeconds(2);

        PurpleCompleteUI.SetActive(false);
        purpleComplete = true;
        StoreData.PurpleComplete = purpleComplete;

    }
}
