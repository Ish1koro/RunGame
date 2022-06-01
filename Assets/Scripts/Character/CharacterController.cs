using UnityEngine;

/// <summary>
/// 敵とプレイヤーの親クラス
/// </summary>
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
    private int _character_Move_Speed = Variables._three;

    private int _life = default;

    private int _state = default;
    #endregion

    #region float

    private float _fall_Timer = default;

    #endregion

    #region bool
    /// <summary>
    /// ダメージ処理の判定
    /// </summary>
    protected bool _isDamage = default;

    /// <summary>
    /// 死亡処理の判定
    /// </summary>
    protected bool _isDeath = default;

    /// <summary>
    /// 地面の着地判定
    /// </summary>
    /// <returns>Groundのレイヤーだったらtrue</returns>
    protected bool _isGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, Variables._character_height, Variables._ground_Layer);
    }

    public bool _isJump = default;
    public bool _isPause = default;
    #endregion

    //-------------------------------------------------------------

    protected virtual void Awake()
    {
        _animc = GetComponent<AnimationController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    //-------------------------------------------------------------

    protected virtual void Update()
    {
        InputMethod();

        // 移動
        Move();

        // 着地判定によって変更
        if (_isGround())
        {
            // ジャンプ中であれば
            if (_isJump)
            {
                // ジャンプのメソッド
                Jump();

                return;
            }
            _fall_Timer = Variables._zero;
        }
        else
        {
            // 落下のメソッド
            Fall();
        }

        // velocityに入れる
        _rb.velocity = (Vector3)_move_Vector;
    }

    //-------------------------------------------------------------

    private void FixedUpdate()
    {
        CharacterAnimation();
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 入力のクラス(親ではいじらない)
    /// </summary>
    protected virtual void InputMethod()
    {

    }

    //-------------------------------------------------------------

    /// <summary>
    /// Characterの移動
    /// </summary>
    protected virtual void Move()
    {
        _move_Vector.x = _character_Move_Speed;
    }

    //-------------------------------------------------------------
    
    /// <summary>
    /// Jump処理
    /// </summary>
    protected virtual void Jump()
    {
        _move_Vector.y += Variables._two;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 重力の処理
    /// </summary>
    private void Fall()
    {
        _fall_Timer += Time.deltaTime;

        _move_Vector.y = Variables._default_Gravity / (_fall_Timer * _fall_Timer);
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
    private void CharacterAnimation()
    {
        if (_isDeath)
        {
            _state = (int)Variables.CharaStats.Death;
        }
        else
        {
            if (_isJump)
            {
                _state = (int)Variables.CharaStats.Jump;
            }
            else if (!_isGround() && !_isJump)
            {
                _state = (int)Variables.CharaStats.Fall;
            }
            else if (_isDamage)
            {
                _state = (int)Variables.CharaStats.Damage;
            }
            else
            {
                _state = (int)Variables.CharaStats.Walk;
            }
        }

        _animc.Animation(_state);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 死亡した際の処理
    /// </summary>
    private void Death()
    {

    }

    //-------------------------------------------------------------
}