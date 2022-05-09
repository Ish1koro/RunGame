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
    public static int _ten { get; } = 10;

    public static int _ground_Layer { get; } = 1 << 8;
    #endregion

    #region string
    /// <summary>
    /// Inputのaction名
    /// </summary>
    public static string _jump { get; } = "Jump";

    public static string _name_Field { get; } = "NameField";
    #endregion

    #region float
    public static float _character_height { get; } = 0.26f;

    public static float _chracter_jump_height { get; } = 5;

    public static float _default_Gravity { get; } = -9.8f;
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

    #region SceneName
    public static string _title { get; } = "Title";
    public static string _mainGame { get; } = "MainGame";
    #endregion
}
