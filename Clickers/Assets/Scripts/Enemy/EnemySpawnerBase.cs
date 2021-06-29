using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemySpawnerBase : MonoBehaviour
{
    protected List<Enemy> activeEnemies = new List<Enemy>();

    private void OnEnable()
    {
        Enemy.OnDeactiveate += Remove;
    }

    private void OnDisable()
    {
        Enemy.OnDeactiveate -= Remove;
    }

    public void Add(Enemy enemy)
    {
        activeEnemies.Add(enemy);
    }

    public void Remove()
    {
        activeEnemies.RemoveAt(activeEnemies.Count - 1);
    }

}
