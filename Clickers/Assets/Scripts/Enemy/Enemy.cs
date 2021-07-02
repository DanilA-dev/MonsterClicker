using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public  class Enemy : MonoBehaviour, IDestroyable
{
    [Header("Enemy Settings")]
    [SerializeField] private HealthSystem health;
    [SerializeField] private int scoreForKill;
    [SerializeField] private int defaultDamageTap = 10;


    public static event Action OnDeactivate;

    private event Action OnEnemyDie;

    private void OnEnable()
    {
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
        health.GetDamage(defaultDamageTap, this, OnEnemyDie);
    }

    public void Destroy()
    {
        health.Death(this);
        ScoreSystem.AddScore(scoreForKill);
        OnDeactivate?.Invoke();
    }



}

