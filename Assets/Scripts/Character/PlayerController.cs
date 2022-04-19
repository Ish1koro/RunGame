using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    #region ‘¼ƒNƒ‰ƒXQÆ
    /// <summary>
    /// Player‚Ì“ü—Í‚ğ‚Æ‚é
    /// </summary>
    private PlayerInput _playerin = default;

    /// <summary>
    /// Jump‚ÌCurve
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
