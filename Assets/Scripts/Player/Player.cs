using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        /*
        rigid.AddForce(inputVec); 
        rigid.velocity = inputVec;
        */

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; // fixedDeltaTime : 물리 프레임 하나가 소비한 시간
        rigid.MovePosition(rigid.position + nextVec);
    }
} 
