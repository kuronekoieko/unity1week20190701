using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    Animator animator;
    [SerializeField] Text rankText;

    public void Init()
    {
        animator = GetComponent<Animator>();
    }

    public void SetResultRank()
    {
        string rank = "D";
        if (Variables.getHeartNum > 100)
        {
            rank = "S";
        }
        else if (Variables.getHeartNum > 90)
        {
            rank = "A";
        }
        else if (Variables.getHeartNum > 70)
        {
            rank = "B";
        }
        else if (Variables.getHeartNum > 50)
        {
            rank = "C";
        }
        else
        {
            rank = "D";
        }

        rankText.text = "RANK : " + rank;
    }

    public void FadeInAnim()
    {
        animator.SetTrigger("FadeIn");
    }

    void ScaleUpAnimEvent()
    {
        animator.SetTrigger("ScaleUp");
    }

}
