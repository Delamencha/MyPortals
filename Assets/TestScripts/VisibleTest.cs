using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleTest : MonoBehaviour
{

    //[SerializeField] MeshRenderer renderer;
    [SerializeField] Camera camera;
    MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(!CameraUtility.VisibleFromCamera(renderer, camera))
        {
            Debug.Log("can't see it");
            renderer.enabled = false;
        }
        else
        {
            renderer.enabled = true;
        }
    }


}
