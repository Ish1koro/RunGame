using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation", menuName = "ScriptableObjects/Animation")]
public class AnimationData : ScriptableObject
{
    public Sprite[] Idle = default;
    public Sprite[] Walk = default;
    public Sprite[] Dash = default;
    public Sprite[] Jump = default;
    public Sprite[] Fall = default;
    public Sprite[] Damage = default;
}
