using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField, Header("ƒLƒƒƒ‰‚Ì”Ô†")] private int _charaNumber = default;

    public void SetUseCharacter()
    {
        GameObject.FindWithTag(Variables._gameController).GetComponent<PlayerData>().SetCharacter(_charaNumber);
    }
}
