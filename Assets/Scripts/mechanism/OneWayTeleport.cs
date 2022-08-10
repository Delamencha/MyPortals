using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayTeleport : MonoBehaviour
{
    [SerializeField] Transform linkedPortal;
    [SerializeField] Transform portal;

 
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct > 0)
            {
                Teleport(player.transform);
                
            }
            
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
