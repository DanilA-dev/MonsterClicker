using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ASpawner
{

    [SerializeField] private EnemySpawnerBase EnemySpawnBase;



    private void OnEnable()
    {
        DisableSpawnerBaff.OnSpawnerDisable += DisableSpawnerBaff_OnSpawnerDisable;
    }


    private void OnDisable()
    {
        DisableSpawnerBaff.OnSpawnerDisable -= DisableSpawnerBaff_OnSpawnerDisable;
    }

    protected override void Start()
    {
        base.Start();
        StartSpawn();
    }


    private void DisableSpawnerBaff_OnSpawnerDisable(bool baffIsEnabled)
    {
        switch(baffIsEnabled)
        {
            case true:
                StopAllCoroutines();
                    break;
            case false:
                StartSpawn();
                break;
        }
    }

    

    public override void StartSpawn()
    {
        StartCoroutine(SpawnRoutine(spawnerParams.SpawnTime));
    }

    protected override IEnumerator SpawnRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        SpawnEnemy();
        spawnerParams.SpawnTime -= 0.1f;
        StartSpawn();
    }

    private void SpawnEnemy()
    {
        var newFreeObject = objectPooler.GetFreeObject();
        Enemy newEnemy = newFreeObject.GetComponent<Enemy>();

        newEnemy.IsClickable = true;
        EnemySpawnBase.Add(newEnemy);
        newEnemy.transform.position = Extensions.GetRandomPos(spawnerParams.MinX, spawnerParams.MaxX, spawnerParams.MinZ, spawnerParams.MaxZ);
    }
}
