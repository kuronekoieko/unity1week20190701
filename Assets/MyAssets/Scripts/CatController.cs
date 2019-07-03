using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody rb;
    public static CatController i;
    float keyX;


    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        i = this;
    }

    // Update is called once per frame
    public void FixedUpd()
    {
        float x = keyX * 6;
        rb.velocity = new Vector3(x, 0, Values.CAT_SPEED);
        //Debug.Log(rb.velocity);
    }

    public void Upd()
    {
        keyX = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            keyX = 1;
            Debug.Log(rb.velocity);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            keyX = -1;
        }

    }

}
