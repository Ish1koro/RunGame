using UnityEngine;

/// <summary>
/// プレイヤーの入力、処理
/// </summary>
public class PlayerController : CharacterController
{
    #region 他クラス参照
    private PlayerInput _playerin = default;
    #endregion

    #region GameObject
    [SerializeField] private GameObject _pauseUI = default;
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
    }

    //-------------------------------------------------------------

    protected override void Update()
    {
        // ポーズ処理
        Pause();

        if (!_isPause)
        {
            base.Update();

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

        _isPause = _playerin.InGame.Pause.triggered;

    }

    //-------------------------------------------------------------

    /// <summary>
    /// ジャンプのメソッド
    /// </summary>
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

    private void Pause()
    {
        if (_isPause)
        {
            _pauseUI.SetActive(true);
            Time.timeScale = Variables._zero;
        }
        else
        {
            _pauseUI.SetActive(false);
            Time.timeScale = Variables._one;
        }
    }

    //-------------------------------------------------------------

    private void OnEnable()
    {
        _playerin.Enable();
    }

    private void OnDisable()
    {
        _playerin.Disable();
    }
}