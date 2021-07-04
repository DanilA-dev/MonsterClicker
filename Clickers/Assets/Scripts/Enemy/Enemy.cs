using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public  class Enemy : ASpawnObject, IDestroyable, IClickable
{
    [Header("Enemy Settings")]
    [SerializeField] private HealthSystem health;
    [SerializeField] private int scoreForKill;
    [SerializeField] private int defaultDamageTap = 10;
    [SerializeField] private bool isClickable;

    [SerializeField] private UnityEvent OnReincarnation;

    public bool IsClickable { get => isClickable; set => isClickable = value; }

    public static event Action OnDeactivate;

    private event Action OnEnemyDie;

    private void OnEnable()
    {
        OnReincarnation?.Invoke();
        OnEnemyDie += Destroy;
    }

    private void OnDisable()
    {
        OnEnemyDie -= Destroy;
    }

    private void Start()
    {
        health.InitHealth();
    }

    private void OnMouseDown()
    {
        Click();
    }

    public void Destroy()
    {
        health.Death(this);
        ScoreSystem.AddScore(scoreForKill);
        OnDeactivate?.Invoke();
    }

    public void Click()
    {
        if (!isClickable)
            return;

        health.GetDamage(defaultDamageTap, this, OnEnemyDie);
    }
}

