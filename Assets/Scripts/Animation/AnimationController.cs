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
    private AnimationData _charaAnimation = default;

    private SpriteRenderer _spriteRenderer = default;

    private PlayerData _playerData = default;
    #endregion

    #region int
    private float[] _count = new float[Variables._seven];
    #endregion

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _charaAnimation = _anim[GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>()._use_Character];
        Debug.Log(GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>()._use_Character);
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
                if ((int)_count[state] < _charaAnimation.Walk.Length - Variables._one)
                {
                    _count[state] += Time.deltaTime;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                _spriteRenderer.sprite = _charaAnimation.Idle[(int)_count[state]];
                return;

            case (int)Variables.CharaStats.Walk:
                if ((int)_count[state] < _charaAnimation.Walk.Length - Variables._one)
                {
                    _count[state] += Time.deltaTime;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                _spriteRenderer.sprite = _charaAnimation.Walk[(int)_count[state]];
                return;

            case (int)Variables.CharaStats.Dash:
                if ((int)_count[state] < _charaAnimation.Dash.Length - Variables._one)
                {
                    _count[state] += Time.deltaTime;
                }
                else
                {
                    _count[state] = Variables._zero;
                }
                _spriteRenderer.sprite = _charaAnimation.Dash[(int)_count[state]];
                return;

            case (int)Variables.CharaStats.Jump:
                if ((int)_count[state] < _charaAnimation.Jump.Length - Variables._one)
                {
                    _count[state] += Time.deltaTime;
                }

                _spriteRenderer.sprite = _charaAnimation.Jump[(int)_count[state]];
                return;

            case (int)Variables.CharaStats.Fall:
                if ((int)_count[state] < _charaAnimation.Fall.Length - Variables._one)
                {
                    _count[state] += Time.deltaTime;
                }
                _spriteRenderer.sprite = _charaAnimation.Fall[(int)_count[state]];
                return;

            case (int)Variables.CharaStats.Damage:
                if (_count[state] < _charaAnimation.Damage.Length - Variables._one)
                {
                    _count[state] += Time.deltaTime;
                }
                else
                {
                    _count[state] = Variables._zero;
                    
                }
                _spriteRenderer.sprite = _charaAnimation.Damage[(int)_count[state]];
                return;

            case (int)Variables.CharaStats.Death:
                //_spriteRenderer.sprite = _charaAnimation.Death[_count[state]];
                _count[state] += Time.deltaTime;
                return;
        }
    }
}
