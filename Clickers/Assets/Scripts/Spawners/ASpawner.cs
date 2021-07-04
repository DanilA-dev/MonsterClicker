using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract  class ASpawner : MonoBehaviour
{
    [SerializeField] private ASpawnObject prefab;
    [SerializeField] protected SpawnerParams spawnerParams;

    protected ObjectPooler<ASpawnObject> objectPooler;

    protected virtual void Start()
    {
        InitPooler();
    }

    private void InitPooler()
    {
        objectPooler = new ObjectPooler<ASpawnObject>(prefab, this.transform);
        objectPooler.AutoExpand = spawnerParams.AutoExpandable;
        objectPooler.CreatePool(spawnerParams.QuantityInScene);
    }


    public abstract void StartSpawn();


    protected virtual IEnumerator SpawnRoutine(float time)
    {
        yield return new WaitForSeconds(time);
    }

    protected virtual IEnumerator StopSpawnUntil(bool tempBool)
    {
        yield return new WaitUntil(() => tempBool = true);
    }
}

[Serializable]
public class SpawnerParams
{
    [SerializeField] private float spawnTime;
    [SerializeField] private bool autoExpandable;
    [SerializeField] private int quantityInScene;

    [Header("SpawnAround")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;


    #region PROPERTIES

    public float SpawnTime { get => spawnTime; set => spawnTime = value; }
    public bool AutoExpandable { get => autoExpandable; set => autoExpandable = value; }
    public int QuantityInScene { get => quantityInScene; set => quantityInScene = value; }

    public float MinX => minX;
    public float MaxX => maxX;
    public float MinZ => minZ;
    public float MaxZ => maxZ;



    #endregion
}