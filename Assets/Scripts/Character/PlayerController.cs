using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    #region 他クラス参照
    /// <summary>
    /// Playerの入力をとる
    /// </summary>
    private PlayerInput _playerin = default;
    #endregion

    private float _move_Distance = default;
    public float _player_Score
    {
        get { return _move_Distance;}
    }

    //-------------------------------------------------------------

    protected override void Start()
    {
        // 入力クラス取得
        _playerin = GetComponent<PlayerInput>();
        base.Start();
    }

    //-------------------------------------------------------------

    protected override void Update()
    {
        base.Update();
        // 
        GetDistanse();
    }

    //-------------------------------------------------------------

    protected override void Input()
    {
        _isJump = _playerin.actions[Variables._jump].triggered;
    }

    //-------------------------------------------------------------

    protected override void Jump()
    {
        base.Jump();
    }

    //-------------------------------------------------------------
    /// <summary>
    /// ユーザのスコア取得
    /// </summary>
    private void GetDistanse()
    {
        _move_Distance = transform.position.x + Variables._start_position;
    }

    //-------------------------------------------------------------
}
