using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine stateMachine;
    public Animator animatior;
    public Rigidbody2D rigid;
    public SpriteRenderer sprite;

    [Header("이동 속도")]
    public float moveSpeed;
    public float maxMoveSpeed;

    [Header("이동 방향")]
    public Vector2 moveDirection;

    [Header("대시 속도")]
    public float dashSpeed;
    public float maxDashSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(stateMachine.curState);
        if (stateMachine.curState != null)
            stateMachine.curState.Update();
    }

    private void FixedUpdate()
    {
        if (stateMachine.curState != null)
            stateMachine.curState.FixedUpdate();
    }

    public void Move()
    {
        rigid.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
        SetMoveSpeed();
    }

    public void SetMoveSpeed()
    {
        if (Mathf.Abs(rigid.velocity.x) > maxMoveSpeed || Mathf.Abs(rigid.velocity.y) > maxMoveSpeed)
        {
            rigid.velocity = new Vector2(moveDirection.x * maxMoveSpeed, moveDirection.y * maxMoveSpeed);
        }
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
        moveDirection.Normalize();

        if (moveDirection.x != 0)
        {
            sprite.flipX = moveDirection.x < 0;
        }
    }
}

