using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public  class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private int scoreForKill;
    [SerializeField] private int defaultDamageTap = 10;
    [SerializeField] private int maxHealth;

    [SerializeField] private UnityEvent OnNullHealth;
    [SerializeField] private UnityEvent OnHit;
    public static event Action OnDeactivate;

    private HealthSystem health;


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

        ScoreSystem.AddScore(scoreForKill);
    }


    private void OnMouseDown()
    {
        health.GetDamage(defaultDamageTap);
    }

}
