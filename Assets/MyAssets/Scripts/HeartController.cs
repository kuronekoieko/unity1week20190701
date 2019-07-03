using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{

    void Init()
    {

    }

    void Upd()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        var cat = col.gameObject.GetComponent<CatController>();
        if (cat)
        {
            Variables.getHeartNum++;
            Debug.Log(Variables.getHeartNum);
        }
    }
}
