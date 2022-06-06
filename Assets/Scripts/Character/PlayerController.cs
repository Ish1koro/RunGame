using UnityEngine;

/// <summary>
/// プレイヤーの入力、処理
/// </summary>
public class PlayerController : CharacterController
{
    #region 他クラス参照
    private PlayerInput _playerin = default;

    private PlayerData _playerData = default;
    #endregion

    #region float
    private float _move_Distance = default;
    public float _player_Score
    {
        get { return _move_Distance;}
    }
    #endregion

    //-------------------------------------------------------------

    protected override void Awake()
    {
        base.Awake();

        _playerin = new PlayerInput();

        _playerData = GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>();
    }

    //-------------------------------------------------------------

    protected override void Update()
    {
        base.Update();

        // スコアを加算
        GetDistanse();
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Playerの入力をとるメソッド
    /// </summary>
    protected override void InputMethod()
    {
        // ジャンプ入力取得
        _isJump = _playerin.InGame.Jump.triggered;
    }

    //-------------------------------------------------------------

    protected override void Death()
    {
        base.Death();

        _playerData.PlayScore(_player_Score);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// ユーザのスコア取得
    /// </summary>
    private void GetDistanse()
    {
        _move_Distance = transform.position.x + Variables._start_position;
    }

    //InputSystem--------------------------------------------------

    private void OnEnable()
    {
        _playerin.Enable();
    }

    private void OnDisable()
    {
        _playerin.Disable();
    }
}