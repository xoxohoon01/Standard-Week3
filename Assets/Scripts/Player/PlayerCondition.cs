using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    public Condition HP { get { return uiCondition.HP; } }
    public Condition Stamina { get { return uiCondition.Stamina; } }
    public Condition Hunger { get { return uiCondition.Hunger; } }

    public event Action onTakeDamage;

    public void TakePhysicalDamage(int damageAmount)
    {
        HP.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }

    public void Heal(float value)
    {

    }
    public void Eat(float value)
    {

    }
}
