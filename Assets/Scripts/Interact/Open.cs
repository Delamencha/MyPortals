using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    [SerializeField] Transform t;

    bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isOpen)
        {
            t.GetComponent<ObjectMovment>().TriggerMove();
            isOpen = true;
        }
    }

}
