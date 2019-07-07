using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] CatController cat;
    [SerializeField] CameraController cam;
    [SerializeField] Text hearNumText;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] Text countDownText;
    [SerializeField] Text spaceDownText;
    public static GameManager i;
    float countDownNum;
    [NonSerialized] public GameState gameState;
    [SerializeField] Animator resultAnim;

    void Start()
    {
        i = this;
        cat.Init();
        cam.Init();
        enemyManager.Init();
        countDownNum = 5f;
        Variables.getHeartNum = 0;
        gameState = GameState.WAITING;
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
                cat.FixedUpdatePlayState();
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
                    cam.EnableBlur(false);
                }
                break;
            case GameState.COUNT_DOWN:
                CountDown();
                break;
            case GameState.PLAY:
                cam.UpdatePlayState();
                cat.UpdatePlayState();
                enemyManager.Upd();
                break;
            case GameState.RESULT:
                cat.UpdateResultState();
                cam.UpdateResultState();
                resultAnim.SetTrigger("FadeIn");
                spaceDownText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
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
