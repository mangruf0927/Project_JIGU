using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : IPlayerState
{
    public PlayerController player { get; set; }
    public PlayerStateMachine stateMachine { get; set; }


    public PlayerDeadState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.controller;
    }

    public HashSet<PlayerStateEnums> inputHash { get; } = new HashSet<PlayerStateEnums>()
    {
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
        player.animator.Play("Dead");
    }

    public void OnExit()
    {

    }
}
