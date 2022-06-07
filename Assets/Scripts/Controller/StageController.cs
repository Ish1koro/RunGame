using UnityEngine;

public class StageController : MonoBehaviour
{
    #region GameObject
    /// <summary>
    /// 移動させるステージ
    /// </summary>
    [SerializeField] private GameObject[] _stage_Objects = default;

    /// <summary>
    /// 移動させる背景
    /// </summary>
    [SerializeField] private GameObject[] _backGrounds = default;

    /// <summary>
    /// キャラクター
    /// </summary>
    private GameObject _player = default;
    #endregion

    #region Vector2
    /// <summary>
    /// 生成する位置
    /// </summary>
    private Vector2 _stage_Position = default;
    /// <summary>
    /// 背景の位置
    /// </summary>
    private Vector2 _background_Position = default;
    #endregion]

    #region int
    /// <summary>
    /// 移動させるステージの番号
    /// </summary>
    private int _stage_Number = default;
    /// <summary>
    /// 移動させる背景の番号
    /// </summary>
    private int _background_Number = default;
    #endregion


    private void Start()
    {
        _player = GameObject.FindWithTag(Variables._player);
        _stage_Number = (int)Variables.Stage.fall;
        _background_Number = (int)Variables.BackGround.flip;
        _stage_Position = _stage_Objects[_stage_Number].transform.position;
        _background_Position = _backGrounds[_background_Number].transform.position;
    }

    private void Update()
    {
        // ステージをplayerが越えたら
        if (_player.transform.position.x >= _stage_Position.x)
        {
            // ステージを移動させる
            GenerateStage();
        }

        // 背景をplayerが越えたら
        if (_player.transform.position.x >= _background_Position.x)
        {
            // 背景を移動させる
            MoveBackGround();
        }
    }

    /// <summary>
    /// Stage移動
    /// </summary>
    private void GenerateStage()
    {
        // 現在のを入れる
        switch (_stage_Number)
        {
            case (int)Variables.Stage.basic:
                _stage_Number = (int)Variables.Stage.another;
                break;
            case (int)Variables.Stage.another:
                _stage_Number = (int)Variables.Stage.fall;
                break;
            case (int)Variables.Stage.fall:
                _stage_Number = (int)Variables.Stage.basic;
                break;
        }
        // 移動させる位置を更新
        _stage_Position.x += Variables._stage_move;
        // ステージを移動
        _stage_Objects[_stage_Number].transform.position = _stage_Position;
    }

    /// <summary>
    /// 背景移動
    /// </summary>
    private void MoveBackGround()
    {
        // 現在の背景を反転させたものを_background_Numberに入れる
        switch (_background_Number)
        {
            case (int)Variables.BackGround.basic:
                _background_Number = (int)Variables.BackGround.flip;
                break;
            case (int)Variables.BackGround.flip:
                _background_Number = (int)Variables.BackGround.basic;
                break;
        }
        // 移動させる位置の更新
        _background_Position.x += Variables._background_move;
        // 背景の位置を移動
        _backGrounds[_background_Number].transform.position = _background_Position;
    }
}
