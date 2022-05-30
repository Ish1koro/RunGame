// 読み取り専用の変数を定義するクラス
// マジックナンバー防止用
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

    public static int _ground_Layer { get; } = 1 << 8;
    #endregion

    #region float
    /// <summary>
    /// キャラのスタート位置
    /// </summary>
    public static float _start_position { get; } = 1.5f;

    public static float _stage_move { get; } = 7.3f;
    public static float _background_move { get; } = 8.7f;
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

    public static string _player { get; } = "Player";
    #endregion

    #region float
    public static float _character_height { get; } = 0.26f;

    public static float _chracter_jump_height { get; } = 5;

    public static float _default_Gravity { get; } = -9.8f;
    #endregion

    #region SceneName
    public static string _title { get; } = "Title";
    public static string _mainGame { get; } = "MainGame";
    public static string _result { get; } = "Result";
    #endregion

    public enum CharaStats
    {
        Idle,
        Walk,
        Dash,
        Jump,
        Fall,
        Damage,
        Death,
    }

    public enum BackGround
    {
        basic,
        flip
    }

    public enum Stage
    {
        basic,
        another
    }
}
