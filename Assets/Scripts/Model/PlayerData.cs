using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    #region ���N���X�Q��

    /// <summary>
    /// ���O���̓N���X
    /// </summary>
    private InputField _name = default;

    #endregion

    #region ���[�U�̃f�[�^

    /// <summary>
    /// ���[�U�̖��O
    /// </summary>
    private string _player_Name = default;
    public string _get_Name
    {
        get { return _player_Name; }
    }

    /// <summary>
    /// ���[�U���i�񂾋���
    /// </summary>
    private float _player_Score = default;
    public float _get_Score
    {
        get { return _player_Score; }
    }

    /// <summary>
    /// ���[�U���g���L����
    /// </summary>
    private int _select_Character = default;

    /// <summary>
    /// �^�C�g���őI�������L�����N�^�[
    /// </summary>
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
    /// ���O�ݒ�
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
    /// �L�����ݒ�
    /// </summary>
    public void SetCharacter(int charaNumber)
    {
        _select_Character = charaNumber;
    }

    //-------------------------------------------------------------

    /// <summary>
    /// Score�W�v
    /// </summary>
    public void PlayScore(float score)
    {
        _player_Score = score;
    }

    //-------------------------------------------------------------
}
