using UnityEngine;
using System;


[Serializable]
public class HealthSystem
{
    [SerializeField] private int maxHealth;

    public event Action<int> OnHealthChanged;
    public event Action OnDie;


    public void GetDamage(int damageAmount)
    {
        maxHealth -= damageAmount;
        Debug.Log(maxHealth);

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
