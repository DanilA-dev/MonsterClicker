using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public  class Enemy : MonoBehaviour
{
    [SerializeField] private int defaultDamageTap = 10;
    [SerializeField] private int maxHealth;

    [SerializeField] private UnityEvent OnNullHealth;
    [SerializeField] private UnityEvent OnHit;

    public HealthSystem health;

    public static event Action OnDeactivate;


    private void OnEnable()
    {
        health = new HealthSystem(maxHealth);
        health.OnDie += EnemyDie;
        health.OnHealthChanged += EnemyHealthChange;
    }


    private void OnDisable()
    {
        health.OnDie -= EnemyDie;
        health.OnHealthChanged -= EnemyHealthChange;
    }

    private void EnemyHealthChange(int obj)
    {
        OnHit?.Invoke();
    }
 
    public void EnemyDie()
    {
        OnNullHealth?.Invoke();
        OnDeactivate?.Invoke();
    }


    private void OnMouseDown()
    {
        health.GetDamage(defaultDamageTap);
    }

}
