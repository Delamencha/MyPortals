using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotTest : MonoBehaviour
{
    [SerializeField] Transform anotherObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 portalToPlayer = other.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
           // Debug.Log(transform.up);
           // Debug.Log(portalToPlayer);
            Debug.Log(dotProduct);

            //float rotationDiff0 = Quaternion.Angle(transform.rotation, anotherObj.rotation);
            //float rotationDiff1 = Quaternion.Angle(anotherObj.rotation, transform.rotation);

            //Debug.Log( rotationDiff0 );
            //Debug.Log(rotationDiff1);


            //other.transform.Rotate(Vector3.up, rotationDiff0);
        }
    }

}
