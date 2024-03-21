using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : IPlayerState
{
    public PlayerController player { get; set; }
    public PlayerStateMachine stateMachine { get; set; }


    public PlayerDodgeState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.controller;
    }

    public HashSet<PlayerStateEnums> inputHash { get; } = new HashSet<PlayerStateEnums>()
    {
    };

    public HashSet<PlayerStateEnums> logicHash { get; } = new HashSet<PlayerStateEnums>()
    {
        PlayerStateEnums.IDLE
    };

    public void Update()
    {
        if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            stateMachine.ChangeLogicState(PlayerStateEnums.IDLE);
            return;
        }
    }

    public void FixedUpdate()
    {
        player.Dodge();
    }

    public void OnEnter()
    {
        player.isDodge = true;
        player.animator.Play("Dodge");
    }

    public void OnExit()
    {
        player.isDodge = false;
        player.rigid.velocity = new Vector2(0, 0);
    }
}
