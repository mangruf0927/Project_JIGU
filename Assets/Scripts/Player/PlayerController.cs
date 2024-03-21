using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine stateMachine;
    public Animator animator;
    public Rigidbody2D rigid;
    public SpriteRenderer sprite;

    [Header("�̵� �ӵ�")]
    public float moveSpeed;
    public float maxMoveSpeed;

    [Header("�̵� ����")]
    public Vector2 moveDirection;

    [Header("��� �ӵ�")]
    public bool isDodge;
    public float dodgeSpeed;
    public float maxDodgeSpeed;

    [Header("��� ����")]
    public Vector2 dodgeDirection;

    private void Start()
    {
        dodgeDirection = new Vector2(1, 0);
    }

    private void Update()
    {
        Debug.Log(stateMachine.curState);
        Debug.Log(dodgeDirection);
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

    public void SetDodgeDirection(Vector2 direction)
    {
        dodgeDirection = direction;
        dodgeDirection.Normalize();
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
        rigid.velocity = dodgeDirection * dodgeSpeed;
        SetDodgeSpeed();
    }

    public void SetDodgeSpeed()
    {
        if (Mathf.Abs(rigid.velocity.x) > maxDodgeSpeed || Mathf.Abs(rigid.velocity.y) > maxDodgeSpeed)
        {
            rigid.velocity = new Vector2(dodgeDirection.x * maxDodgeSpeed, dodgeDirection.y * maxDodgeSpeed);
        }
    }

}

