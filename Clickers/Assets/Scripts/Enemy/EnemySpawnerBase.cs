using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class EnemySpawnerBase : MonoBehaviour
{
    public static event Action<int> OnEnemiesCountChanged;


    private List<Enemy> activeEnemies = new List<Enemy>();


    private void OnEnable()
    {
        Enemy.OnDeactivate += Remove;
    }

    private void OnDisable()
    {
        Enemy.OnDeactivate -= Remove;
    }

    public void Add(Enemy enemy)
    {
        activeEnemies.Add(enemy);
        OnEnemiesCountChanged?.Invoke(activeEnemies.Count);

        if(activeEnemies.Count >= 10)
        {
            GlobalGameState.Instance.ChangeState(GameState.Over);
        }
    }

    public void Remove()
    {
        activeEnemies.RemoveAt(activeEnemies.Count - 1);
        OnEnemiesCountChanged?.Invoke(activeEnemies.Count);
    }



}
