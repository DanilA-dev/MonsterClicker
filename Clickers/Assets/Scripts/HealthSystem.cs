using UnityEngine;
using UnityEngine.Events;
using System;


public class HealthSystem
{

    private int maxHealth;

    public event Action<int> OnHealthChanged;
    public event Action OnDie;

    public HealthSystem(int restoredHealth)
    {
        maxHealth = restoredHealth;
    }

    public void GetDamage(int damageAmount)
    {
        maxHealth -= damageAmount;

        if (maxHealth <= 0)
        {
            Death();
        }
        OnHealthChanged?.Invoke(maxHealth);       
    }

    private void Death()
    {
        OnDie?.Invoke();
    }


}
