using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlane : MonoBehaviour
{
    [SerializeField] Transform linkedPortal;
    [SerializeField] Transform portal;

    bool readyToTeleport = false;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (readyToTeleport)
        {
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0)
            {
                Teleport(player.transform);
                readyToTeleport = false;
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            readyToTeleport = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            readyToTeleport = false ;
        }
    }

    private void Teleport(Transform player)
    {
        Vector3 relativePosition = portal.transform.InverseTransformPoint(player.position);
        relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));

        Vector3 relativeRotation = portal.transform.InverseTransformDirection(player.forward);
        relativeRotation = Vector3.Scale(relativeRotation, new Vector3(-1, 1, -1));

        player.position = linkedPortal.TransformPoint(relativePosition);
        player.forward = linkedPortal.TransformDirection(relativeRotation);


    }
}
