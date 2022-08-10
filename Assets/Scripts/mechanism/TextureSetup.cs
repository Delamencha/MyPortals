using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSetup : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    public Material cameraMat1;
    public Material cameraMat2;
    public Material cameraMat3;

    void Start()
    {
        if (camera1.targetTexture != null)
        {
            camera1.targetTexture.Release();
        }

        if (camera2.targetTexture != null)
        {
            camera2.targetTexture.Release();
        }

        //if (camera3.targetTexture != null)
        //{
        //    camera3.targetTexture.Release();
        //}

        camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat1.mainTexture = camera1.targetTexture;

        camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat2.mainTexture = camera2.targetTexture;

        //camera3.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //cameraMat3.mainTexture = camera3.targetTexture;
    }
}
