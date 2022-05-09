using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アニメーションを管理するクラス
/// </summary>
public class AnimationController : MonoBehaviour
{
    #region 他クラス参照
    [SerializeField] private AnimationData[] _anim = default;

    private SpriteRenderer _spriteRenderer = default;

    private PlayerData _playerData = default;
    #endregion

    #region int
    private int[] _count = new int[Variables._seven];
    #endregion

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// アニメーション
    /// </summary>
    /// <param name="state">キャラクターの今の状態</param>
    public void Animation(int state)
    {
        switch (state)
        {
            case (int)Variables.CharaStats.Idle:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Idle[_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Idle.GetLength(Variables._zero))
                {
                    _count[state]++;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                return;

            case (int)Variables.CharaStats.Walk:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Walk[_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Walk.GetLength(Variables._zero))
                {
                    _count[state]++;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                return;

            case (int)Variables.CharaStats.Dash:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Dash[_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Dash.GetLength(Variables._zero))
                {
                    _count[state]++;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                return;

            case (int)Variables.CharaStats.Jump:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Jump[_count[state]];
                _count[state]++;
                return;

            case (int)Variables.CharaStats.Fall:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Fall[_count[state]];
                _count[state]++;
                return;

            case (int)Variables.CharaStats.Damage:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Damage[_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Idle.GetLength(Variables._zero))
                {
                    _count[state]++;
                }
                else
                {
                    _count[state] = Variables._zero;
                    
                }
                return;

            case (int)Variables.CharaStats.Death:
                //_spriteRenderer.sprite = _anim[_playerData._use_Character].Death[_count[state]];
                _count[state]++;
                return;
        }
    }
}
