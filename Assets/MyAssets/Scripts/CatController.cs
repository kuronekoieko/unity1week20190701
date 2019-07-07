using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody rb;
    public static CatController i;
    float keyX;
    float centerX;
    Animator animator;

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        i = this;
        keyX = 0;
        centerX = transform.position.x;
    }


    public void FixedUpdatePlayState()
    {
        float x = keyX * 2;
        rb.velocity = new Vector3(x, rb.velocity.y, Values.CAT_SPEED);

        //左右の移動制限
        HorizontalLimitter();

    }


    void HorizontalLimitter()
    {
        float offset = 3f;
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        int sign = 0;
        if (x > centerX + offset) { sign = 1; }
        if (x < centerX - offset) { sign = -1; }
        if (sign != 0) { x = centerX + sign * offset; }
        transform.position = new Vector3(x, y, z);
    }

    public void UpdatePlayState()
    {
        HorizontalController();
        JumpController();
        animator.SetTrigger("Run");
        animator.speed = !IsGround() ? 0.1f : 1.5f;
    }

    public void UpdateResultState()
    {
        rb.velocity = Vector3.zero;
        animator.speed = 1.5f;
    }

    void OnTriggerEnter(Collider other)
    {

        var enemy = other.gameObject.GetComponent<EnemyController>();
        // Debug.Log(enemy);
        if (enemy)
        {
            //  animator.SetTrigger("Damage");
        }

        var goal = other.gameObject.GetComponent<GoalController>();
        if (goal)
        {
            animator.ResetTrigger("Run");
            animator.SetTrigger("Idle");
            GameManager.i.gameState = GameState.RESULT;
        }
    }



    void JumpController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGround()) { return; }
            rb.velocity += new Vector3(0, Values.CAT_JUMP_SPEED, 0);
            AudioManager.i.PlayOneShot(2);
        }
    }

    void HorizontalController()
    {
        keyX = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            keyX = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            keyX = -1;
        }

        keyX = Input.GetAxis("Horizontal");
    }

    bool IsGround()
    {
        //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        float distance = 0.1f;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.red);

        //もしRayにオブジェクトが衝突したら
        //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
        if (Physics.Raycast(ray, out hit, distance))
        {
            //Rayが当たったオブジェクトが存在するか
            return hit.collider;
        }
        return false;
    }

}
