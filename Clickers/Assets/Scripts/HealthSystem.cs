using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class HealthSystem
{

    [SerializeField] private int maxHealth;

    private int defaultHealth;


    [SerializeField] private List<NullHealthEvent> nullHeatlhEvents = new List<NullHealthEvent>();
    [SerializeField] private List<HitHealthEvent> hitHealthEvents = new List<HitHealthEvent>();

    public void InitHealth()
    {
        defaultHealth = maxHealth;
    }

    public void GetDamage(int damageAmount, MonoBehaviour mono, Action deathAction)
    {
        maxHealth -= damageAmount;

        if (maxHealth <= 0)
        {
            deathAction?.Invoke();
           // Death(mono);
            SetDefaultHealth();
        }

        Hit(mono);
    }

    public void Death(MonoBehaviour mono)
    {
        if (nullHeatlhEvents.Count <= 0)
            return;

        foreach (var e in nullHeatlhEvents)
        {
            mono.StartCoroutine(e.Invoke());
        }
    }

    public void Hit(MonoBehaviour mono)
    {
        if (hitHealthEvents.Count <= 0)
            return;

        foreach (var e in hitHealthEvents)
        {
            mono.StartCoroutine(e.Invoke());
        }
    }

    private void SetDefaultHealth()
    {
        maxHealth = defaultHealth;
    }

}

[Serializable]
public class NullHealthEvent
{
    [SerializeField] private UnityEvent OnNullHealth;
    [SerializeField] private float timeToInvoke;

    public IEnumerator Invoke()
    {
        yield return new WaitForSeconds(timeToInvoke);
        OnNullHealth?.Invoke();
    }
}

[Serializable]
public class HitHealthEvent
{
    [SerializeField] private UnityEvent OnHitEvent;
    [SerializeField] private float timeToInvoke;

    public IEnumerator Invoke()
    {
        yield return new WaitForSeconds(timeToInvoke);
        OnHitEvent?.Invoke();
    }
}
