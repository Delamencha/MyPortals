using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleControl : MonoBehaviour
{
    public static List<GameObject> entities;

    [SerializeField] Camera camera;
    [SerializeField] GameObject CubePrefab;

    GameObject realOne;
    GameObject previousOne;

    private void Awake()
    {
        entities = new List<GameObject>();

    }

    void Start()
    {
       StartCoroutine(CoreChange());

    }



    void Update()
    {

        //if (!CameraUtility.VisibleFromCamera(renderer, camera))
        //{
        //    Debug.Log("can't see it");
        //    renderer.enabled = false;
        //}
        //else
        //{
        //    Debug.Log("got it");
        //    renderer.enabled = true;
        //}
    }

    public void SetRealOne(GameObject obj)
    {
        realOne = obj;
    }

    IEnumerator CoreChange()
    {

        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            CheckVisible();
        }

    }

    void CheckVisible()
    {
        List<GameObject> inVisible = new List<GameObject>();
        int sum = 0;
        

        if (entities.Count <= 0) return;
        for(int i=0; i< entities.Count; i++)
        {
            if(!CameraUtility.VisibleFromCamera(entities[i].GetComponent<MeshRenderer>(), camera))
            {

                inVisible.Add(entities[i]);
                sum += 1;
            }

        }

        if(sum >= 1 && !CheckRealOne())
        {

            SwitchPos(sum, inVisible);
        }
    }

    bool CheckRealOne()
    {
        return CameraUtility.VisibleFromCamera(realOne.GetComponent<MeshRenderer>(), camera);
 
    }

    void SwitchPos(int sum, List<GameObject> objs)
    {
        int n = Random.Range(0, sum);
        //移动cube触发onTriggerExit并稍后Destroy该实例
        previousOne = realOne;
        StartCoroutine(DropCube());
        Instantiate(CubePrefab, objs[n].transform.position, Quaternion.identity);

    }

    IEnumerator DropCube()
    {
        previousOne.transform.Translate(new Vector3(0, -3, 0));

        yield return new WaitForSeconds(0.1f);

        Destroy(previousOne);
    }

    

}
