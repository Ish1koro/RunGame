using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    #region 他クラス参照
    /// <summary>
    /// CharacterのAnimationを管理するクラス
    /// </summary>
    private AnimationController _animc = default;

    protected Rigidbody2D _rb = default;
    #endregion

    #region Vector2
    /// <summary>
    /// characterが移動する距離
    /// </summary>
    protected Vector2 _move_Vector = default;
    #endregion

    #region int
    private int _character_Move_Speed = default;

    private int _life = default;

    protected int _move_Direction = Variables._one;
    #endregion

    #region float
    /// <summary>
    /// 重力加速度の時間
    /// </summary>
    private float _fall_Timer = default;

    /// <summary>
    /// Jumpの強さ
    /// </summary>
    /// <returns></returns>
    private float _jumpPower()
    {
        return 1;
    }
    #endregion

    #region bool
    protected bool _isJump = default;

    /// <summary>
    /// 地面の着地判定
    /// </summary>
    /// <returns>Groundのレイヤーだったらtrue</returns>
    protected bool _isGround()
    {
        return Physics2D.BoxCast(transform.position, Vector2.down, 90, Vector2.down * Variables._character_height, Variables._ground_Layer);
    }
    #endregion

    //-------------------------------------------------------------

    protected virtual void Start()
    {
        _animc = GetComponent<AnimationController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    //-------------------------------------------------------------

    protected virtual void Update()
    {
        Move();

        if (_isGround() && _isJump)
        {
            Jump();
        }
        else if (_isGround())
        {
            _move_Vector.y = Variables._zero;
            _fall_Timer = Variables._zero;
        }
        else
        {
            Fall();
        }

        transform.position += (Vector3)_move_Vector;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 入力のクラス(親ではいじらない)
    /// </summary>
    protected virtual void Input()
    {

    }

    //-------------------------------------------------------------

    /// <summary>
    /// Characterの移動
    /// </summary>
    protected virtual void Move()
    {
        _move_Vector.x = _character_Move_Speed * Time.deltaTime;
    }

    //-------------------------------------------------------------
    
    /// <summary>
    /// Jump処理
    /// </summary>
    protected virtual void Jump()
    {
        _move_Vector.y = _jumpPower();
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 重力
    /// </summary>
    private void Fall()
    {
        Debug.Log(_isGround());

        //_fall_Timer += Time.deltaTime;

        //_move_Vector.y = Variables._default_Gravity / (_fall_Timer * _fall_Timer);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// damage処理
    /// </summary>
    /// <param name="damage">攻撃された値</param>
    private void CharaLifeCalculation(int damage)
    {
        _life -= damage;

        if (_life <= Variables._zero)
        {
            Death();
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Animationの処理ををAnimationのクラスに渡す
    /// </summary>
    /// <param name="state">Charaの状態</param>
    private void CharacterAnimation(int state)
    {
        _animc.ChangeAnimation(state);
    }

    //-------------------------------------------------------------


    private void Death()
    {

    }

    //-------------------------------------------------------------
}