using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody rb;
    public static CatController i;
    float keyX;


    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        i = this;
        keyX = 0;
    }

    // Update is called once per frame
    public void FixedUpd()
    {
        float x = keyX * 6;
        rb.velocity = new Vector3(x, rb.velocity.y, Values.CAT_SPEED);
        //Debug.Log(rb.velocity);
    }

    public void Upd()
    {
        HorizontalController();
        JumpController();

    }

    void JumpController()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGround()) { return; }
            rb.velocity += new Vector3(0, 7, 0);
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
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider)
            {
                Debug.Log("接地");
            }
            return hit.collider;
        }
        return false;
    }

}
