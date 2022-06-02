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
    #endregion

    #region int
    /// <summary>
    /// Spriteの最後
    /// </summary>
    private int[] _animation_Length = new int[Variables._seven];
    #endregion

    #region float
    /// <summary>
    /// Spriteが切り替わるスピード
    /// 式: アニメーションする時間 / Spriteの数
    /// </summary>
    private float[] _animation_Speed = new float[Variables._seven];

    /// <summary>
    /// 現在のスプライト
    /// </summary>
    private float[] _animation_Count = new float[Variables._seven];
    #endregion

    //-------------------------------------------------------------

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _charaAnimation = _anim[GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>()._use_Character];
        
        GetAnimationLength();

        SetAniamtionSpeed();
    }

    //-------------------------------------------------------------

    /// <summary>
    /// 使用するキャラのアニメーションを設定
    /// </summary>
    private void GetAnimationLength()
    {
        int animation_count = default;
        _animation_Length[animation_count] = _charaAnimation.Idle.Length;
        animation_count++;
        _animation_Length[animation_count] = _charaAnimation.Walk.Length;
        animation_count++;
        _animation_Length[animation_count] = _charaAnimation.Dash.Length;
        animation_count++;
        _animation_Length[animation_count] = _charaAnimation.Jump.Length;
        animation_count++;
        _animation_Length[animation_count] = _charaAnimation.Fall.Length;
        animation_count++;
        _animation_Length[animation_count] = _charaAnimation.Damage.Length;
        
        for (int count = default; count < (int)Variables.CharaStats.Length; count++)
        {
            _animation_Speed[count] = 30 / _animation_Length[count];
        }
    }

    //-------------------------------------------------------------

    /// <summary>
    /// アニメーションするスピードを設定
    /// </summary>
    private void SetAniamtionSpeed()
    {
        Debug.Log((int)Variables.CharaStats.Length);
        
    }

    //-------------------------------------------------------------

    /// <summary>
    /// アニメーション
    /// </summary>
    /// <param name="state">今のキャラの状態</param>
    /// <param name="old_State">前の処理のキャラの状態</param>
    public void Animation(int state, int old_State)
    {
        // 前回の処理と状態が違ったら
        if (state != old_State)
        {
            // _snimation_Countを0にする
            _animation_Count[state] = Variables._zero;
        }

        // Spriteが最後に行くまで加算
        if ((int)_animation_Count[state] < _animation_Length[state] - Variables._one)
        {
            _animation_Count[state] += Time.deltaTime * _animation_Speed[state];
        }
        else if (state < Variables._three)
        {
            // Spriteが最後の場合は0に戻す
            _animation_Count[state] = Variables._zero;
        }

        // stateによりSpriteの配列を変更
        switch (state)
        {
            case (int)Variables.CharaStats.Idle:
                // int型に変更し適応
                _spriteRenderer.sprite = _charaAnimation.Idle[(int)_animation_Count[state]];
                return;

            case (int)Variables.CharaStats.Walk:
                _spriteRenderer.sprite = _charaAnimation.Walk[(int)_animation_Count[state]];
                return;

            case (int)Variables.CharaStats.Dash:
                _spriteRenderer.sprite = _charaAnimation.Dash[(int)_animation_Count[state]];
                return;

            case (int)Variables.CharaStats.Jump:
                _spriteRenderer.sprite = _charaAnimation.Jump[(int)_animation_Count[state]];
                return;

            case (int)Variables.CharaStats.Fall:
                _spriteRenderer.sprite = _charaAnimation.Fall[(int)_animation_Count[state]];
                return;

            case (int)Variables.CharaStats.Damage:
                _spriteRenderer.sprite = _charaAnimation.Damage[(int)_animation_Count[state]];
                return;

            #region 現在未実装
            case (int)Variables.CharaStats.Death:
                //_spriteRenderer.sprite = _charaAnimation.Death[_count[state]];
                return;
            #endregion
        }
    }
}