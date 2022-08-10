using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlane : MonoBehaviour,Interactable
{
    public event Action playerInteract;


    private void Update()
    {

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grabable")
        {
            playerInteract();
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabable")
        {
            playerInteract();
        }
    }






}
