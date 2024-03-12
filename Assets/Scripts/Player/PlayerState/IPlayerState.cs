using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    PlayerController player { get; set; }
    PlayerStateMachine stateMachine { get; set; }

    // >> : ����Ʈ�� �ڱ��ڽ��� ���� ������ ���� ��� ���� \ get : ���� �������� �͸� ����
    HashSet<PlayerStateEnums> inputHash { get; } // Ű �Է¹޾��� �� ����Ǵ� state
    HashSet<PlayerStateEnums> logicHash { get; } // ������ ����Ǵ� state

    void Update();
    void FixedUpdate();
    void OnEnter();
    void OnExit();
}
