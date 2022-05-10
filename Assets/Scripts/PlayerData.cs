using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    #region 他クラス参照
    /// <summary>
    /// 名前入力クラス
    /// </summary>
    private InputField _name = default;

    #endregion

    #region ユーザのデータ

    /// <summary>
    /// ユーザの名前
    /// </summary>
    private string _player_Name = default;

    /// <summary>
    /// ユーザが進んだ距離
    /// </summary>
    private float _player_Distance = default;

    /// <summary>
    /// ユーザが使うキャラ
    /// </summary>
    private int _select_Character = default;

    public int _use_Character
    {
        get { return _select_Character; }
    }

    #endregion

    //-------------------------------------------------------------

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 名前設定
    /// </summary>
    public void EnterName()
    {
        if (GameObject.FindWithTag(Variables._name_Field).TryGetComponent(out _name))
        {
            _player_Name = _name.text;
        }
    }
    
    //-------------------------------------------------------------

    /// <summary>
    /// キャラ設定
    /// </summary>
    public void SetCharacter(int charaNumber)
    {
        _select_Character = charaNumber;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 
    /// </summary>
    public void PlayDistance()
    {

    }

    //-------------------------------------------------------------
}
