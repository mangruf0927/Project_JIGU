using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

        Vector2 nextVec = inputVec.normalized * speed;
        rigid.AddForce(nextVec, ForceMode2D.Impulse);
    }

    void LateUpdate()
    {
        // inputVec.magnitude; //벡터의 순수한 크기 값

        if (inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
    }
} 
