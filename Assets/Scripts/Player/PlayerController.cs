using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine stateMachine;
    public Animator animatior;
    public Rigidbody2D rigid;

    [Header("이동 속도")]
    public float moveSpeed;
    public float maxSpeed;

    [Header("이동 방향")]
    public Vector2 moveDirection;

    private void Start()
    {
        
    }

    private void Update()
    {
        //Debug.Log(stateMachine.curState);
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
        if (Mathf.Abs(rigid.velocity.x) > maxSpeed || Mathf.Abs(rigid.velocity.y) > maxSpeed)
        {
            rigid.velocity = new Vector2(moveDirection.x * maxSpeed, moveDirection.y * maxSpeed);
        }
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction;
        moveDirection.Normalize();
    }
}
