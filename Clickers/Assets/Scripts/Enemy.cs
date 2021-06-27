using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public  class Enemy : MonoBehaviour
{
    [SerializeField] private int defaultDamageTap = 10;
    [SerializeField] protected HealthSystem health;

    [SerializeField] private UnityEvent OnNullHealth;


    private void OnEnable()
    {
        health.OnDie += Health_OnDie;
    }
    private void OnDisable()
    {
        health.OnDie -= Health_OnDie;
    }

 
    private void Health_OnDie()
    {
        OnNullHealth?.Invoke();
    }


    private void OnMouseDown()
    {
        health.GetDamage(defaultDamageTap);
    }

}
