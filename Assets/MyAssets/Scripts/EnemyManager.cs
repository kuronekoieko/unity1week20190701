using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyController[] enemies;
    public void Init()
    {
        enemies = new EnemyController[transform.childCount];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = transform.GetChild(i).GetComponent<EnemyController>();
            enemies[i].Init();
        }

    }

    public void Upd()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Upd();
        }
    }
}
