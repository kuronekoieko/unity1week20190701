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
    [SerializeField] Text countDownText;
    [SerializeField] Text spaceDownText;
    float countDownNum;
    GameState gameState;

    void Start()
    {
        cat.Init();
        cam.Init();
        enemyManager.Init();
        countDownNum = 5f;
    }

    void FixedUpdate()
    {

        switch (gameState)
        {
            case GameState.WAITING:

                break;
            case GameState.COUNT_DOWN:

                break;
            case GameState.PLAY:
                cat.FixedUpd();
                break;
            case GameState.RESULT:

                break;

            default:
                break;
        }
    }

    void Update()
    {

        hearNumText.text = Variables.getHeartNum.ToString();
        switch (gameState)
        {
            case GameState.WAITING:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    spaceDownText.gameObject.SetActive(false);
                    gameState = GameState.COUNT_DOWN;
                }
                break;
            case GameState.COUNT_DOWN:
                CountDown();
                break;
            case GameState.PLAY:
                cam.Upd();
                cat.Upd();
                enemyManager.Upd();
                break;
            case GameState.RESULT:

                break;

            default:
                break;
        }

    }

    void CountDown()
    {
        countDownNum -= Time.deltaTime;
        float num = Mathf.Ceil(countDownNum);
        countDownText.text = num.ToString("F0");
        if (num == 0)
        {
            countDownText.gameObject.SetActive(false);
            gameState = GameState.PLAY;
        }
    }


}
