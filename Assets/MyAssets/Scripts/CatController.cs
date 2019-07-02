using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody rb;
    public static CatController i;

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        i = this;
    }

    // Update is called once per frame
    public void Upd()
    {
        rb.velocity = new Vector3(0, 0, 5);
    }
}
