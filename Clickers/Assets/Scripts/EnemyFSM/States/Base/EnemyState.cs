using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EnemyStates/NewEnemyState")]
public class EnemyState : ScriptableObject
{
   [SerializeField] private List<EnemyAction> actions;

    public void InitState(EnemyStateController stateController)
    {
        InitActions(stateController);
    }

    public void UpdateState(EnemyStateController stateController)
    {
        DoActions(stateController);
    }

    private void DoActions(EnemyStateController stateController)
    {
        foreach (var action in actions)
        {
            action.Execute(stateController);
        }
    }

    private void InitActions(EnemyStateController stateController)
    {
        foreach (var action in actions)
        {
            action.Init(stateController);
        }
    }

}
