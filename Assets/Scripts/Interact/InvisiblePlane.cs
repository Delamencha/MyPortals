using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlane : MonoBehaviour, Interactable
{
    public event Action playerInteract;

    bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasTriggered)
        {

            Vector3 planeToPlayer = other.transform.position - transform.position;

            float dotProduct = Vector3.Dot(transform.forward, planeToPlayer);

            if (dotProduct < 0 )
            {
                playerInteract();
                hasTriggered = true;
            }

        }

        
    }

}
