using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderButton : MonoBehaviour, Interactable
{
    [SerializeField] Transform cylinder;

    public event Action playerInteract;

    bool isPressed = false;
    bool hasPressed = false;

    public void Interact()
    {
        if (!isPressed)
        {
            StartCoroutine(press());
            if (!hasPressed)
            {
                playerInteract();
                hasPressed = true;
            }
            
        }

    }

    IEnumerator press()
    {
        isPressed = true;
        cylinder.Translate(new Vector3(0, -0.05f, 0));
        cylinder.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        cylinder.Translate(new Vector3(0, 0.05f, 0));
        cylinder.GetComponent<MeshRenderer>().material.color = Color.gray;
        isPressed = false;
    }
}
