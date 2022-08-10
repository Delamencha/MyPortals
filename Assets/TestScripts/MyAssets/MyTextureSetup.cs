using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTextureSetup : MonoBehaviour
{

    public Camera camera_B;
    public Material mat_A;


    void Start()
    {
        
        if(camera_B.targetTexture != null)
        {
            camera_B.targetTexture.Release();
        }

        camera_B.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mat_A.mainTexture = camera_B.targetTexture;


    }

}
