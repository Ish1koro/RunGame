/// <summary>
/// 読み取り専用の変数を定義するクラス
/// </summary>
public static class Variables
{
    #region int 
    public static int _zero { get; } = 0;
    public static int _one { get; } = 1;
    public static int _two { get; } = 2;
    public static int _three { get; } = 3;
    public static int _four { get; } = 4;
    public static int _five { get; } = 5;
    public static int _six { get; } = 6;
    public static int _seven { get; } = 7;
    public static int _eight { get; } = 8;
    public static int _ten { get; } = 10;

    /// <summary>
    /// 地面のレイヤー
    /// </summary>
    public static int _ground_Layer { get; } = 1 << 8;
    #endregion

    #region float
    /// <summary>
    /// キャラのスタート位置
    /// </summary>
    public static float _start_position { get; } = 1.5f;

    /// <summary>
    /// ステージの動く距離
    /// </summary>
    public static float _stage_move { get; } = 7.3f;

    /// <summary>
    /// 背景の動く距離
    /// </summary>
    public static float _background_move { get; } = 8.7f;

    /// <summary>
    /// 自機の大きさ
    /// </summary>
    public static float _character_height { get; } = 0.26f;

    /// <summary>
    /// 自機の横幅
    /// </summary>
    public static float _chara_width { get; } = 0.08f;

    /// <summary>
    /// 重力の大きさ
    /// </summary>
    public static float _default_Gravity { get; } = -9.8f;
    #endregion

    #region string
    /// <summary>
    /// Scoreの単位
    /// </summary>
    public static string _unit { get; } = "M";

    /// <summary>
    /// Inputのaction名
    /// </summary>
    public static string _jump { get; } = "Jump";
    
    /// <summary>
    /// Inputのaction名
    /// </summary>
    public static string _pause { get; } = "Pause";

    /// <summary>
    /// 名前入力欄のタグ
    /// </summary>
    public static string _name_Field { get; } = "NameField";
    
    /// <summary>
    /// playerData格納場所
    /// </summary>
    public static string _gameController { get; } = "GameController";

    /// <summary>
    /// Player
    /// </summary>
    public static string _player { get; } = "Player";

    /// <summary>
    /// サーバーのurl
    /// </summary>
    public static string _url { get; } = "153.120.3.118/var/www/Test.php";
    #endregion

    #region SceneName
    public static string _title { get; } = "Title";
    public static string _mainGame { get; } = "MainGame";
    public static string _result { get; } = "Result";
    #endregion

    #region enum

    /// <summary>
    /// キャラの状態
    /// </summary>
    public enum CharaStats
    {
        Idle,
        Walk,
        Dash,
        Jump,
        Fall,
        Damage,
        Length
    }

    /// <summary>
    /// 背景の種類
    /// </summary>
    public enum BackGround
    {
        basic,
        flip
    }

    /// <summary>
    /// ステージの種類
    /// </summary>
    public enum Stage
    {
        basic,
        another,
        fall
    }

    #endregion
}