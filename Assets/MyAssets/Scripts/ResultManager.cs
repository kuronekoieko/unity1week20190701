using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    Animator animator;

    public void Init()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeInAnim()
    {
        animator.SetTrigger("FadeIn");
    }

    void ScaleUpAnim()
    {
        animator.SetTrigger("ScaleUp");
    }

}
