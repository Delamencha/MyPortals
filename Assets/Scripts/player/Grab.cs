using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    [SerializeField] float grabRange = 3f;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform holdParent;
    [SerializeField] float moveForce = 250f;
    [SerializeField] KeyCode grabKey = KeyCode.R;

    private GameObject heldObj;

    void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, grabRange)) ;
                {
                    if(hit.transform != null && hit.transform.tag == "Grabable")
                    {
                        PickUpObj(hit.transform.gameObject);
                    }
                    
                }
            }
            else
            {
                DropObj();
            }
        }

        //if(heldObj !=null)
        //{
        //    MoveObj();
        //}

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 1f)) ;
            if (hit.transform != null && hit.transform.tag == "Interactable")
            {
                hit.transform.GetComponent<CylinderButton>().Interact();
            }
        }

    }

    void MoveObj()
    {
        if (Vector3.Distance(heldObj.transform.position, transform.position) > 0.1f)
        {
            Vector3 moveDirection = (transform.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickUpObj( GameObject pickObj)
    {
        Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
        if (objRig != null)
        {
            objRig.useGravity = false;
            //objRig.drag = 10f;
            objRig.freezeRotation = true;

            pickObj.transform.position = holdParent.position;
            pickObj.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }



    void DropObj()
    {
        Rigidbody objRig = heldObj.GetComponent<Rigidbody>();

        objRig.useGravity = true;
        //objRig.drag = 1;
        objRig.freezeRotation = false;

        heldObj.transform.parent = null;
        heldObj = null;
        
    }

}
