using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTest : MonoBehaviour
{

    [SerializeField] GameObject landmark;
    [SerializeField] Transform linkedPortal;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Teleport();
        }
    }

    private void Teleport()
    {
       

        var relativePosition = transform.InverseTransformPoint(player.transform.position);
        relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));
        

        //GameObject copyInstance = Instantiate(landmark, teleportLocation, Quaternion.identity);

        var relativeRotation = transform.InverseTransformDirection(player.transform.forward);
        relativeRotation = Vector3.Scale(relativeRotation, new Vector3(-1, 1, 1));

        player.transform.position = linkedPortal.TransformPoint(relativePosition);
        player.transform.forward = linkedPortal.TransformDirection(relativeRotation);


        //Vector3 portalToPlayer = player.transform.position - transform.position;
        //portalToPlayer = Vector3.Scale(portalToPlayer,new Vector3(1, 1, -1));
        //teleportLocation = linkedPortal.position + portalToPlayer;



        
        
    }
}
