using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private bool AutoExpandable;
    [SerializeField] private int quantityInScene;
    [SerializeField] private Enemy prefab;


    [Header("Spawn positions")] 
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;


    private EnemySpawnerBase spawnBase;
    private ObjectPooler<Enemy> enemyPooler;

    private void Start()
    {
        spawnBase = GetComponentInParent<EnemySpawnerBase>();
        InitPooler();
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
        spawnBase.Add(newActiveEnemy);
        newActiveEnemy.transform.position = Extensions.GetRandomPos(minX, maxX, minZ, maxZ);
        spawnTime -= 0.01f;
        StartSpawn();
    }

   private void InitPooler()
    {
        enemyPooler = new ObjectPooler<Enemy>(prefab, this.transform);
        enemyPooler.AutoExpand = AutoExpandable;
        enemyPooler.CreatePool(quantityInScene);
    }

}
