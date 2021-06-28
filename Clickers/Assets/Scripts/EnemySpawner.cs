using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int quantityInScene;
    [SerializeField] private Enemy prefab;

    [SerializeField] private float spawnTime;

    [Header("Spawn positions")] // v noviy class
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    private ObjectPooler<Enemy> enemyPooler;

    private void Start()
    {
        enemyPooler = new ObjectPooler<Enemy>(prefab, this.transform);
        enemyPooler.CreatePool(quantityInScene);
        StartSpawn();
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(spawnTime);
        var newActiveEnemy =  enemyPooler.GetFreeObject();
        newActiveEnemy.transform.position = Extensions.GetRandomPos(minX, maxX, minZ, maxZ);
        spawnTime -= 0.01f;
        StartSpawn();
    }
   

}
