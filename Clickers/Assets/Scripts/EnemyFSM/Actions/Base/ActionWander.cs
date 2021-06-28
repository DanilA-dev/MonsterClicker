using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName ="EnemyActions/Wander")]
public class ActionWander : EnemyAction
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxBreakTime;

    [Header("Walk Around")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    private float currentBreakTime;
    private Vector3 newPos;

    public override void Init(EnemyStateController stateController)
    {
        stateController.NavMeshAgent.speed = moveSpeed;
    }

    public override void Execute(EnemyStateController stateController)
    {
        Patrol(stateController);
    }

    private void Patrol(EnemyStateController stateController)
    {
        newPos = Extensions.GetRandomPos(minX, maxX, minZ, maxZ);

        if(currentBreakTime <= 0)
        {
            stateController.NavMeshAgent.destination = newPos;
            currentBreakTime = maxBreakTime;
        }
        else
        {
            currentBreakTime -= Time.deltaTime;
        }
    }

}
