using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        //if (playerIsOverlapping)
        //{
        //    Vector3 portalToPlayer = player.position - transform.position;
        //    float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            
        //    Debug.Log(dotProduct);

        //    if(dotProduct < 0f)
        //    {
        //        playerIsOverlapping = false;
        //    }

            // see if player moved across the portal
            //if(dotProduct < 0f)
            //{
                

            //    float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
            //    rotationDiff += 180;
            //    player.Rotate(Vector3.up, rotationDiff);

            //    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
            //    Debug.Log("processing");
                
            //    player.position = receiver.position + positionOffset;
                

            //    playerIsOverlapping = false;

               
                
            //}

        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            Debug.Log(transform.up);
            Debug.Log(portalToPlayer);
            Debug.Log(dotProduct);

            if (dotProduct < 0f)
            {


                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);

                Debug.Log("rotationDiff:  "+ rotationDiff);

                rotationDiff += 180;
               // player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
               

                player.position = receiver.position + positionOffset;


                playerIsOverlapping = false;



            }

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        playerIsOverlapping = false;
    //    }
    //}
}
