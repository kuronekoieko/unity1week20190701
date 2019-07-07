using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CameraController : MonoBehaviour
{
    public static CameraController i;
    Vector3 vec;
    public Blur blur { set; get; }
    float timeCount;

    public void Init()
    {
        i = this;
        vec = CatController.i.transform.position - transform.position;
        blur = GetComponent<Blur>();
        EnableBlur(true);
    }

    // Update is called once per frame
    public void UpdatePlayState()
    {
        float x = (CatController.i.transform.position - vec).x;
        float y = transform.position.y;
        float z = (CatController.i.transform.position - vec).z;
        transform.position = new Vector3(x, y, z);
    }
    public void UpdateResultState()
    {
        if (timeCount > 1f)
        {
            EnableBlur(true);
            return;
        }
        timeCount += Time.deltaTime;
    }


    public void EnableBlur(bool isActive)
    {
        blur.enabled = isActive;
    }

}
