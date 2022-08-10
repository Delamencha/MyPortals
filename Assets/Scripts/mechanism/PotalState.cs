using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalState : MonoBehaviour
{
    [SerializeField] GameObject switchObj;
    [SerializeField] GameObject teleportPlane;

    bool isOpen = false;

    private void Start()
    {
        SwitchTeleport();
    }

    private void OnEnable()
    {
        switchObj.GetComponent<Interactable>().playerInteract += SwitchTeleport;
    }


    void SwitchTeleport()
    {
        teleportPlane.SetActive(isOpen);
        isOpen = !isOpen;

    }

}
