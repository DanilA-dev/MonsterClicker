using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int quantityInScene;
    [SerializeField] private Enemy prefab;

    [SerializeField] private float maxTime;

    private float currentTime;

    private ObjectPooler<Enemy> enemyPooler;

    private void Start()
    {
        enemyPooler = new ObjectPooler<Enemy>(prefab, quantityInScene, this.transform);
        currentTime = maxTime;
    }

    private void Update()
    {
        if(currentTime <= 0)
        {
            Debug.Log("A");
            enemyPooler.GetFreeObject();
            currentTime = maxTime;
        }
        else
        {
          currentTime -= Time.deltaTime;
        }
    }
}
