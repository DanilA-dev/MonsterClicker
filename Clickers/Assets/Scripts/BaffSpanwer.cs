using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaffSpanwer : ASpawner
{
    protected override void Start()
    {
        base.Start();
        StartSpawn();
    }


    public override void StartSpawn()
    {
        StartCoroutine(SpawnRoutine(spawnerParams.SpawnTime));
    }

    protected override IEnumerator SpawnRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        BaffSpawn();
        StartSpawn();
    }

    private void BaffSpawn()
    {
        var newFreeObj = objectPooler.GetFreeObject();
        var spawnPoint = Extensions.GetRandomPos(spawnerParams.MinX, spawnerParams.MaxX, spawnerParams.MinZ, spawnerParams.MaxZ);
        spawnPoint.y += 1f;

        newFreeObj.transform.position = spawnPoint;
    }
}
