using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    public PlayerController player { get; set; }
    public PlayerStateMachine stateMachine { get; set; }

    // 생성자의 주요 목적은 객체를 초기화하고 초기 상태로 설정하는 것
    public PlayerIdleState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.controller;
    }

    public HashSet<PlayerStateEnums> inputHash { get; } = new HashSet<PlayerStateEnums>()
    {
        PlayerStateEnums.MOVE,
        PlayerStateEnums.DODGE
    };

    public HashSet<PlayerStateEnums> logicHash { get; } = new HashSet<PlayerStateEnums>()
    {
    };

    public void Update()
    {

    }

    public void FixedUpdate()
    {

    }

    public void OnEnter()
    {
        player.animator.Play("Idle");
    }

    public void OnExit()
    {

    }
}
