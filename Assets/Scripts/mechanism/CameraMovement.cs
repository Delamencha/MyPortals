using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform portal;
    [SerializeField] Transform linkedPortal;

    GameObject player;
    Camera playerCamera;

    float xRotation = 0f;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerCamera = player.GetComponentInChildren<Camera>();
    }

    void LateUpdate()
    {

        Vector3 relativePosition = linkedPortal.InverseTransformPoint(playerCamera.transform.position);
        relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));

        //FPSController的视角左右旋转与上下旋转不在同一个object上,该方法不适用
        //Vector3 relativeDirection = linkedPortal.InverseTransformDirection(player.transform.forward);
        //relativeDirection = Vector3.Scale(relativeDirection, new Vector3(-1, 1, -1));

        //----------

        float angularDifferenceBetweenPortalPotation = Quaternion.Angle(portal.rotation, linkedPortal.rotation);
        angularDifferenceBetweenPortalPotation += 180;
        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalPotation, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        //------------

        transform.position = portal.TransformPoint(relativePosition);
        //transform.forward = portal.TransformDirection(relativeDirection);


    }
}
