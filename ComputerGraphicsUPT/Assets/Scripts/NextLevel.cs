using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(++scene);
        }
    }
}
