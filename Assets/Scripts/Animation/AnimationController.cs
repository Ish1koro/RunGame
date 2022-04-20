using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animation _anim = default;

    public void ChangeAnimation(int state)
    {
        switch (state)
        {
            case (int)Variables.CharaStats.Idle:
                break;
        }
    }
}
