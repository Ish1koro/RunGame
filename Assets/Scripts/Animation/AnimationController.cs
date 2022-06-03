using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�j���[�V�������Ǘ�����N���X
/// </summary>
public class AnimationController : MonoBehaviour
{
    #region ���N���X�Q��
    [SerializeField] private AnimationData[] _anim = default;
    private AnimationData _charaAnimation = default;

    private SpriteRenderer _spriteRenderer = default;
    #endregion

    #region int
    /// <summary>
    /// Sprite�̍Ō�
    /// </summary>
    private int[] _animation_Length = new int[Variables._seven];
    #endregion

    #region float
    /// <summary>
    /// Sprite���؂�ւ��X�s�[�h
    /// ��: �A�j���[�V�������鎞�� / Sprite�̐�
    /// </summary>
    private float[] _animation_Speed = new float[Variables._six];

    /// <summary>
    /// ���݂̃X�v���C�g
    /// </summary>
    private float[] _animation_Count = new float[Variables._six];
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
    /// �g�p����L�����̃A�j���[�V������ݒ�
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
    /// �A�j���[�V��������X�s�[�h��ݒ�
    /// </summary>
    private void SetAniamtionSpeed()
    {
        Debug.Log((int)Variables.CharaStats.Length);
        
    }

    //-------------------------------------------------------------

    /// <summary>
    /// �A�j���[�V����
    /// </summary>
    /// <param name="state">���̃L�����̏��</param>
    /// <param name="old_State">�O�̏����̃L�����̏��</param>
    public void Animation(int state, int old_State)
    {
        // �O��̏����Ə�Ԃ��������
        if (state != old_State)
        {
            // _snimation_Count��0�ɂ���
            _animation_Count[state] = Variables._zero;
        }

        // Sprite���Ō�ɍs���܂ŉ��Z
        if ((int)_animation_Count[state] < _animation_Length[state] - Variables._one)
        {
            _animation_Count[state] += Time.deltaTime * _animation_Speed[state];
        }
        else if (state < Variables._three)
        {
            // Sprite���Ō�̏ꍇ��0�ɖ߂�
            _animation_Count[state] = Variables._zero;
        }

        // state�ɂ��Sprite�̔z���ύX
        switch (state)
        {
            case (int)Variables.CharaStats.Idle:
                // int�^�ɕύX���K��
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
        }
    }
}