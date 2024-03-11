using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    public PlayerController player { get; set; }
    public PlayerStateMachine stateMachine { get; set; }

    // �������� �ֿ� ������ ��ü�� �ʱ�ȭ�ϰ� �ʱ� ���·� �����ϴ� ��
    public PlayerMoveState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.controller;
    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {
        player.Move();
    }

    public void OnEnter()
    {
        player.animatior.Play("Move");
    }

    public void OnExit()
    {
        player.rigid.velocity = new Vector2(0, 0);
    }
}