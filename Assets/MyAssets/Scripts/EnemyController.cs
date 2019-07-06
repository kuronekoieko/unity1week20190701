using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    float timer;
    bool isFinishedMove;
    float dz;
    public int initdirection;
    public void Init()
    {
        isFinishedMove = true;
        dz = 5 * Mathf.Sign(initdirection);
    }

    public void Upd()
    {

        if (!isFinishedMove) { return; }
        isFinishedMove = false;
        transform.DOMoveX(
                   transform.position.x + dz,  //移動後の座標
                   1.0f       //時間
                   ).OnComplete(() =>
                   {
                       isFinishedMove = true;
                       dz *= -1;
                   });

    }


    public void FixedUpd()
    {

    }
}
