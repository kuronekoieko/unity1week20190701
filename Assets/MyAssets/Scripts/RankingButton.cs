using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingButton : MonoBehaviour
{
    public void OnClick()
    {
        // Type == Number の場合
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Variables.getHeartNum);
    }
}
