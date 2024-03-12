using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    public PlayerController player { get; set; }
    public PlayerStateMachine stateMachine { get; set; }


    public PlayerMoveState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.controller;
    }

    public HashSet<PlayerStateEnums> inputHash { get; } = new HashSet<PlayerStateEnums>()
    {
        PlayerStateEnums.IDLE,
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
        player.Move();
    }

    public void OnEnter()
    {
        player.animator.Play("Move");
    }

    public void OnExit()
    {
        player.rigid.velocity = new Vector2(0, 0);
    }
}