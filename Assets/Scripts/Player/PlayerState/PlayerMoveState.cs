using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    public PlayerController player { get; set; }
    public PlayerStateMachine stateMachine { get; set; }

    // 생성자의 주요 목적은 객체를 초기화하고 초기 상태로 설정하는 것
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