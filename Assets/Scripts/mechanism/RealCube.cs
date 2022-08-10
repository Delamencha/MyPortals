using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCube : MonoBehaviour
{

    private void OnEnable()
    {
        FindObjectOfType<VisibleControl>().SetRealOne(gameObject);
    }

}
