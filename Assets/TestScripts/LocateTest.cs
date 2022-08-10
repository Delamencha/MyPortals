using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateTest : MonoBehaviour
{

    [SerializeField] Transform portal;
    [SerializeField] Transform otherPortal;
    [SerializeField] Transform target;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(transform.position + "    "+ transform.rotation);
        }
    }

    void LateUpdate()
    {
        var relativePosition = otherPortal.InverseTransformPoint(target.position);
        relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));
        transform.position = portal.TransformPoint(relativePosition);

        var relativeRotation = otherPortal.InverseTransformDirection(target.forward);
        relativeRotation = Vector3.Scale(relativeRotation, new Vector3(-1, 1, -1));
        transform.forward = portal.TransformDirection(relativeRotation);
    }
}
