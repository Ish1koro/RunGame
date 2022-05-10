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
    private float[] _count = new float[Variables._seven];
    #endregion

    private void Start()
    {
        _playerData = GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// アニメーション
    /// </summary>
    /// <param name="state">キャラクターの今の状態</param>
    public void Animation(int state)
    {
        Debug.Log(_count[state]);
        Debug.Log(_anim[_playerData._use_Character].Fall.GetLength(Variables._zero));
        switch (state)
        {
            case (int)Variables.CharaStats.Idle:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Idle[(int)_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Idle.GetLength(Variables._zero))
                {
                    _count[state] += Time.deltaTime;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                return;

            case (int)Variables.CharaStats.Walk:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Walk[(int)_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Walk.GetLength(Variables._zero))
                {
                    _count[state] += Time.deltaTime;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                return;

            case (int)Variables.CharaStats.Dash:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Dash[(int)_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Dash.GetLength(Variables._zero))
                {
                    _count[state] += Time.deltaTime;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                return;

            case (int)Variables.CharaStats.Jump:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Jump[(int)_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Jump.GetLength(Variables._zero))
                {
                    _count[state] += Time.deltaTime;
                }

                return;

            case (int)Variables.CharaStats.Fall:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Fall[(int)_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Fall.GetLength(Variables._zero))
                {
                    _count[state] += Time.deltaTime;
                }
                return;

            case (int)Variables.CharaStats.Damage:
                _spriteRenderer.sprite = _anim[_playerData._use_Character].Damage[(int)_count[state]];
                if (_count[state] < _anim[_playerData._use_Character].Damage.GetLength(Variables._zero))
                {
                    _count[state] += Time.deltaTime;
                }
                else
                {
                    _count[state] = Variables._zero;
                    
                }
                return;

            case (int)Variables.CharaStats.Death:
                //_spriteRenderer.sprite = _anim[_playerData._use_Character].Death[_count[state]];
                _count[state] += Time.deltaTime;
                return;
        }
    }
}
