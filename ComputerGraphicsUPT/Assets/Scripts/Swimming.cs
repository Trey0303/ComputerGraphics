using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    public SamplePlayerCharacter player;

    //public bool IsSwimming = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SamplePlayerCharacter>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Data.IsSwimming = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Data.IsSwimming = false;
        }
    }
}
