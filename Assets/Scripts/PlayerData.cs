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

    /// <summary>
    /// Player�̖��O
    /// </summary>
    private string _player_Name = default;

    /// <summary>
    /// Player���i�܂�������
    /// </summary>
    private float _player_Distance = default;

    private int _select_Character = default;

    public int _use_Character
    {
        get { return _select_Character; }
    }


    public void EnterName()
    {
        if (GameObject.FindWithTag(Variables._name_Field).TryGetComponent(out _name))
        {
            _player_Name = _name.text;
        }
    }

    public void PlayDistance()
    {

    }
}
