using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleEntity : MonoBehaviour
{

    void Start()
    {
            VisibleControl.entities.Add(gameObject);
            GetComponent<MeshRenderer>().enabled = false;
   
    }


}
