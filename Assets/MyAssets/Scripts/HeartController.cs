using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    [SerializeField] ParticleSystem lightPS;
    [SerializeField] ParticleSystem heartPS;
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
            gameObject.SetActive(false);
            lightPS.Play();
            heartPS.Play();
        }
    }
}
