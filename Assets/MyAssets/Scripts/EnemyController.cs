using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    float timer;
    bool isFinishedMove;
    public void Init()
    {
        isFinishedMove = true;
    }

    public void Upd()
    {

        if (!isFinishedMove) { return; }
        isFinishedMove = false;
        transform.DOMoveX(
                   transform.position.x + 5,  //移動後の座標
                   1.0f       //時間
                   ).OnComplete(() =>
                   {
                       isFinishedMove = true;
                   });
        Debug.Log("aaaaaa");
    }


    public void FixedUpd()
    {

    }
}
