using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : MonoBehaviour
{
    [SerializeField] private EnemyState currentState;

    [SerializeField] private NavMeshAgent navMeshAgent;


    #region PROPERTIES

    public NavMeshAgent NavMeshAgent { get => navMeshAgent; }

    #endregion

    private void Start()
    {
        InitState();
    }

    private void Update()
    {
        ExecuteState();
    }

    private void InitState()
    {
        currentState.InitState(this);
    }

    private void ExecuteState()
    {
        currentState.UpdateState(this);
    }


}
