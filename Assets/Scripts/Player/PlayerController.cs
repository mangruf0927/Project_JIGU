using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine stateMachine;
    public Animator animator;
    public Rigidbody2D rigid;
    public SpriteRenderer sprite;

    [Header("이동 속도")]
    public float moveSpeed;
    public float maxMoveSpeed;

    [Header("이동 방향")]
    public Vector2 moveDirection;

    [Header("대시 속도")]
    public bool isDodge;
    public float dodgeSpeed;
    public float maxDodgeSpeed;

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
    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
        moveDirection.Normalize();

        if (moveDirection.x != 0)
        {
            sprite.flipX = moveDirection.x < 0;
        }
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

    public void Dodge()
    {
        rigid.velocity = moveDirection * dodgeSpeed;
        SetDodgeSpeed();
    }

    public void SetDodgeSpeed()
    {
        if (Mathf.Abs(rigid.velocity.x) > maxDodgeSpeed || Mathf.Abs(rigid.velocity.y) > maxDodgeSpeed)
        {
            rigid.velocity = new Vector2(moveDirection.x * maxDodgeSpeed, moveDirection.y * maxDodgeSpeed);
        }
    }

}

