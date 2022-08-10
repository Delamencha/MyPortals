using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameta : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;


    void LateUpdate()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalPotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalPotation, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        //----------------------------


        //GetComponent<Camera>().projectionMatrix = playerCamera.GetComponent<Camera>().projectionMatrix;

        //var relativePosition = otherPortal.InverseTransformPoint(playerCamera.position);
        //relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));
        //transform.position = portal.TransformPoint(relativePosition);

        //var relativeRotation = otherPortal.InverseTransformDirection(playerCamera.forward);
        //relativeRotation = Vector3.Scale(relativeRotation, new Vector3(-1, 1, -1));
        //transform.forward = portal.TransformDirection(relativeRotation);


    }
}
