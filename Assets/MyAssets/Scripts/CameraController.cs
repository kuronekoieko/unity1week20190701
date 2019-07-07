using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController i;
    Vector3 vec;
    public void Init()
    {
        i = this;
        vec = CatController.i.transform.position - transform.position;
    }

    // Update is called once per frame
    public void UpdatePlayState()
    {
        float x = (CatController.i.transform.position - vec).x;
        float y = transform.position.y;
        float z = (CatController.i.transform.position - vec).z;
        transform.position = new Vector3(x, y, z);
    }
}
