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

    [SerializeField] private AnimationCurve _jumpCurve = default;

    [SerializeField] private AnimationCurve _fallCurve = default;
    #endregion

    #region Vector2
    /// <summary>
    /// characterが移動する力
    /// </summary>
    protected Vector2 _move_Vector = default;

    /// <summary>
    /// 着地判定時Rayを出すX座標の位置
    /// </summary>
    private Vector2 _horizontal = new Vector2(0.08f, 0);

    /// <summary>
    /// キャラのX座標の大きさ
    /// </summary>
    private Vector2 _vertical = new Vector2(0, 0.21f);
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
    /// ジャンプしている時間
    /// </summary>
    private float _jump_Timer = default;

    /// <summary>
    /// ジャンプ時の初速度計算
    /// </summary>
    /// <returns> -初速度(m/s) ＝ 重力 * 時間(s) - 速度(m/s)</returns>
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
    protected bool _isJump = default;

    /// <summary>
    /// ジャンプ中の判定
    /// </summary>
    private bool _isJumping = default;

    /// <summary>
    /// 地面の着地判定
    /// </summary>
    /// <returns>Groundのレイヤーだったらtrue</returns>
    protected bool _isGround()
    {
        bool hit = !Physics2D.Raycast(transform.position + (Vector3)_horizontal, Vector2.down, Variables._character_height, Variables._ground_Layer) && !Physics2D.Raycast(transform.position - (Vector3)_horizontal, Vector2.down, Variables._character_height, Variables._ground_Layer);


        if (hit)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 移動不可能の判定
    /// </summary>
    /// <returns></returns>
    protected bool _canMove()
    {
        bool hit = !Physics2D.Raycast(transform.position + (Vector3)_vertical, Vector2.right, Variables._character_height, Variables._ground_Layer) && !Physics2D.Raycast(transform.position - (Vector3)_vertical, Vector2.right, Variables._character_height, Variables._ground_Layer);
        if (hit)
        {
            return true;
        }
        return false;
    }
    #endregion

    //-------------------------------------------------------------

    protected virtual void Awake()
    {
        _animc = GetComponent<AnimationController>();
        _character_Move_Speed = Variables._three;
    }

    //-------------------------------------------------------------

    protected virtual void Update()
    {
        Debug.Log(_isGround());
        // 入力
        InputMethod();

        // 移動
        Move();

        if ((_isGround() && _isJump) || _isJumping)
        {
            // ジャンプの処理
            Jump();
        }
        else if (_isGround())
        {
            // 着地時の処理
            OnGround();
        }
        else if (!_isJumping)
        {
            // 落下処理
            Fall();
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
        transform.position += (Vector3)_move_Vector;
        if (_canMove())
        {
            _move_Vector.x = _character_Move_Speed * Time.deltaTime;
        }
        else
        {
            _move_Vector.x = Variables._zero;
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Jump処理
    /// </summary>
    protected virtual void Jump()
    {
        // ジャンプのフラグを立てる
        if (!_isJumping)
        {
            _isJumping = true;
        }
        
        // ジャンプしている時間を加算
        _jump_Timer += Time.deltaTime;

        // veloctyに入れる
        _move_Vector.y = _jumpCurve.Evaluate(_jump_Timer) * 2 * Time.deltaTime;

        // ジャンプ時間が1秒以上だったら
        if (_jump_Timer >= Variables._max_Jump_Time)
        {
            // フラグを消す
            _isJumping = false;
            _jump_Timer = Variables._zero;
        }
    }

    //-------------------------------------------------------------

    private void OnGround()
    {
        _move_Vector.y = Variables._zero;

        _fall_Timer = Variables._zero;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 重力の処理
    /// </summary>
    private void Fall()
    {
        _fall_Timer += Time.deltaTime;
        _move_Vector.y += Variables._default_Gravity * _fallCurve.Evaluate(_fall_Timer) * Time.deltaTime;
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
        if (_isJump || _isJumping)
        {
            _state = (int)Variables.CharaStats.Jump;
        }
        else if (!_isGround())
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

    protected virtual void OnBecameInvisible()
    {
        
    }

    //-------------------------------------------------------------
}