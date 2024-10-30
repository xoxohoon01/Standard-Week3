using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition HP;
    public Condition Stamina;
    public Condition Hunger;

    private void Start()
    {
        CharacterManager.Instance.Player.playerCondition.uiCondition = this;
    }
}
