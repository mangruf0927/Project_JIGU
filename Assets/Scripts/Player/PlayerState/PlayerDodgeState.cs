using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : IPlayerState
{
    public PlayerController player { get; set; }
    public PlayerStateMachine stateMachine { get; set; }

    // �������� �ֿ� ������ ��ü�� �ʱ�ȭ�ϰ� �ʱ� ���·� �����ϴ� ��
    public PlayerDodgeState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.controller;
    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {

    }

    public void OnEnter()
    {
        player.animatior.Play("Dodge");
    }

    public void OnExit()
    {

    }
}
