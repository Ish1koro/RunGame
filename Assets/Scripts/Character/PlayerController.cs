using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    #region ���N���X�Q��
    /// <summary>
    /// Player�̓��͂��Ƃ�
    /// </summary>
    private PlayerInput _playerin = default;

    /// <summary>
    /// Jump��Curve
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
