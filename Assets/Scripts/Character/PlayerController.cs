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

    #region GameObject
    /// <summary>
    /// ポーズ時のUI
    /// </summary>
    [SerializeField] private GameObject _pause_UI = default;
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
        
        // ポーズ処理
        Pause();

        //ポーズ状態じゃなければ
        if (!_isPause)
        {
            // スコアを加算
            GetDistanse();
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Playerの入力をとるメソッド
    /// </summary>
    protected override void InputMethod()
    {
        // ジャンプ入力取得
        _isJump = _playerin.InGame.Jump.triggered;

        // ポーズ入力取得
        _isPause = _playerin.InGame.Pause.triggered;
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

    //-------------------------------------------------------------

    /// <summary>
    /// ポーズTimeScaleを0にする
    /// </summary>
    private void Pause()
    {
        if (_isPause)
        {
            _pause_UI.SetActive(true);
            Time.timeScale = Variables._zero;
        }
        else
        {
            _pause_UI.SetActive(false);
            Time.timeScale = Variables._one;
        }
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