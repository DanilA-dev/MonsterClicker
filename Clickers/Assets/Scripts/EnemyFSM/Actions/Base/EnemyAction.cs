using UnityEngine;

public abstract class EnemyAction : ScriptableObject
{
    public abstract void Init(EnemyStateController stateController);
    public abstract void Execute(EnemyStateController stateController);
}
