using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public delegate void PlayerHandler();
    public event PlayerHandler OnPlayerIdle;
    public event PlayerHandler OnPlayerMove;
    public event PlayerHandler OnPlayerDodge;

    public delegate void PlayerVectorHandler(Vector2 value);
    public event PlayerVectorHandler OnPlayerCheckDirection;
    public event PlayerVectorHandler OnPlayerDodgeDirection;

    void Update()
    {
#if UNITY_EDITOR
        // 이동
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            OnPlayerMove?.Invoke();

            Vector2 inputDodgeVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            OnPlayerDodgeDirection?.Invoke(inputDodgeVector);
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 )
        {
            OnPlayerIdle?.Invoke();
        }
        
        // 방향 체크
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnPlayerCheckDirection?.Invoke(inputVector);

        // 대시
        if (Input.GetButtonDown("Fire3"))
        {
            OnPlayerDodge?.Invoke();
        }
#endif
    }
}

