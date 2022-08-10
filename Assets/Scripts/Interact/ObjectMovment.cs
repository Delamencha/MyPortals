using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovment : MonoBehaviour
{

    [SerializeField] Transform destination;
    [SerializeField] float speed =1f;
    [SerializeField] GameObject triggerPlane;

    Vector3 location_1;
    Vector3 location_2;
    bool isOpening = true;

    private void Awake()
    {
        location_1 = transform.position;
        location_2 = destination.position;
    }

    private void Update()
    {

  
    }

    private void OnEnable()
    {
        if(triggerPlane != null)
        {
            triggerPlane.GetComponent<Interactable>().playerInteract += TriggerMove;
        }
        
    }

    //private void OnDisable()
    //{
    //    triggerPlane.GetComponent<TriggerPlane>().Pressed -= TriggerMove;
    //}

    IEnumerator Move(Vector3 start, Vector3 end)
    {

        float travelPercent = 0;
        isOpening = !isOpening;

        while (travelPercent < 1f)
        {
            travelPercent += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start, end, travelPercent);
            yield return new WaitForEndOfFrame();
        }


    }


    public void TriggerMove()
    {

        StartCoroutine(Move(transform.position, isOpening ? location_2 : location_1));
    }



}
