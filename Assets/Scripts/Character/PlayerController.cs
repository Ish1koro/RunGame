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

    /// <summary>
    /// JumpのCurve
    /// </summary>
    private AnimationCurve _jump_Curve = default;
    #endregion
    
    //-------------------------------------------------------------

    protected override void Start()
    {
        base.Start();
        _playerin = GetComponent<PlayerInput>();

    }

    //-------------------------------------------------------------

    protected override void Update()
    {
        
    }

    //-------------------------------------------------------------
}
