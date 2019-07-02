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
    public void Upd()
    {
        transform.position = CatController.i.transform.position - vec;
    }
}
