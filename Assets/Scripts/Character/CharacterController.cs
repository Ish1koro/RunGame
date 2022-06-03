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
    /// characterが移動する力
    /// </summary>
    protected Vector2 _move_Vector = default;
    #endregion

    #region int
    /// <summary>
    /// キャラの動くスピード
    /// </summary>
    private int _character_Move_Speed = default;

    /// <summary>
    /// キャラのライフ
    /// </summary>
    private int _life = default;

    /// <summary>
    /// キャラの状態
    /// </summary>
    private int _state = default;

    /// <summary>
    /// 前回の処理でのキャラの状態
    /// </summary>
    private int _old_Character_State = default;
    #endregion

    #region float
    /// <summary>
    /// 重力で使用予定
    /// </summary>
    private float _fall_Timer = default;

    /// <summary>
    /// ジャンプ時の初速度計算
    /// </summary>
    /// <returns> -初速度(m/s)＝重力 * 時間(s)- 速度(m/s)</returns>
    private float _Initialvelocity()
    {
        return Mathf.Sqrt(-Variables._default_Gravity * Variables._two - Variables._two);
    }
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
    /// ジャンプ開始の判定
    /// </summary>
    public bool _isJump = default;

    /// <summary>
    /// ポーズの判定
    /// </summary>
    public bool _isPause = default;
    
    /// <summary>
    /// 地面の着地判定
    /// </summary>
    /// <returns>Groundのレイヤーだったらtrue</returns>
    protected bool _isGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, Variables._character_height, Variables._ground_Layer);
    }
    #endregion

    //-------------------------------------------------------------

    protected virtual void Awake()
    {
        _animc = GetComponent<AnimationController>();
        _rb = GetComponent<Rigidbody2D>();
        _character_Move_Speed = Variables._three;
    }

    //-------------------------------------------------------------

    protected virtual void Update()
    {
        Debug.Log(_Initialvelocity());
        // 入力
        InputMethod();

        if (!_isPause)
        {
            // 移動
            Move();

            // 着地判定によって変更
            if (_isGround())
            {
                // 着地しているときの処理
                Jump();
            }
            else
            {
                // 落下のメソッド
                Fall();
            }
        }
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
        // velocityに入れる
        _rb.velocity = (Vector3)_move_Vector;

        // 
        _move_Vector.x = _character_Move_Speed;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Jump処理
    /// </summary>
    protected virtual void Jump()
    {
        // 落下していないときに0にする
        if (_fall_Timer != Variables._zero)
        {
            _fall_Timer = Variables._zero;
        }

        // ジャンプが押されたら
        /// 速度(m/s)＝加速度(m/s2)×時間(s) + 初速度(m/s)
        if (_isJump || _rb.velocity.y != Variables._zero)
        {
            _move_Vector.y = Variables._default_Gravity * Variables._one;
        }
        else
        {
            _rb.gravityScale = Variables._zero;

            _move_Vector.y = Variables._zero;
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 重力の処理
    /// </summary>
    private void Fall()
    {
        _fall_Timer += Time.deltaTime;
        _move_Vector.y += Variables._default_Gravity / (_fall_Timer * _fall_Timer) * Time.deltaTime;
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
        if (_isJump || _rb.velocity.y > Variables._zero)
        {
            _state = (int)Variables.CharaStats.Jump;
        }
        else if (!_isGround() || _rb.velocity.y < Variables._zero)
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

        _animc.Animation(_state, _old_Character_State);

        _old_Character_State = _state;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 死亡した際の処理
    /// </summary>
    protected virtual void Death()
    {

    }

    //-------------------------------------------------------------
}