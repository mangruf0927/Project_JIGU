using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("플레이어 컨트롤러")]
    public PlayerController controller;

    [HideInInspector] 
    public IPlayerState curState;

    public Dictionary<PlayerEnums, IPlayerState> stateDictionary;

    private void Awake()
    {
        stateDictionary = new Dictionary<PlayerEnums, IPlayerState>
        {
            {PlayerEnums.IDLE, new PlayerIdleState(this) },
            {PlayerEnums.MOVE, new PlayerMoveState(this) },
            {PlayerEnums.DODGE, new PlayerDodgeState(this) },
            {PlayerEnums.DEAD, new PlayerDeadState(this) },
        };

        if(stateDictionary.TryGetValue(PlayerEnums.IDLE, out IPlayerState newState))
        {
            // TryGetValue : Key가 있는지 확인과 동시에 Value도 반환
            curState = newState;
            curState.OnEnter();
        }
    }

    public void ChangeState(PlayerEnums newStateType)
    {
        if (curState == null) return;
        curState.OnExit();

        if (stateDictionary.TryGetValue(newStateType, out IPlayerState newState))
        {
            curState = newState;
            curState.OnEnter();
        }
    }
}
