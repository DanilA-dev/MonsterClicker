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

    private HealthSystem health;

    public static event Action OnDeactiveate;


    private void OnEnable()
    {
        health = new HealthSystem(maxHealth);
        health.OnDie += Health_OnDie;
        health.OnHealthChanged += Health_OnHealthChanged;
    }


    private void OnDisable()
    {
        health.OnDie -= Health_OnDie;
        health.OnHealthChanged -= Health_OnHealthChanged;
    }

    private void Health_OnHealthChanged(int obj)
    {
        OnHit?.Invoke();
    }
 
    private void Health_OnDie()
    {
        OnNullHealth?.Invoke();
        OnDeactiveate?.Invoke();
    }


    private void OnMouseDown()
    {
        health.GetDamage(defaultDamageTap);
    }

}
