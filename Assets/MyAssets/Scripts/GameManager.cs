using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] CatController cat;
    [SerializeField] CameraController cam;
    [SerializeField] Text hearNumText;
    [SerializeField] EnemyManager enemyManager;

    void Start()
    {
        cat.Init();
        cam.Init();
        enemyManager.Init();
    }

    void FixedUpdate()
    {
        cat.FixedUpd();
    }

    void Update()
    {
        cam.Upd();
        cat.Upd();
        enemyManager.Upd();
        hearNumText.text = Variables.getHeartNum.ToString();
    }


}
