using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public enum BaffState
{
    Ready,
    Activated,
    CoolDown
}

public abstract class ABaff : MonoBehaviour, IClickable
{

    [SerializeField] protected BaffParams baffParams;
    [SerializeField] private List<BaffEvent> baffEvents = new List<BaffEvent>();


    protected BaffState state;


    #region PROPERTIES

    public abstract bool IsClickable { get; set; }

    public BaffState State
    {
        get => state;
        set
        {
            state = value;
            OnStateEnter?.Invoke(value);
        }
    }

    #endregion

    #region EVENTS

    private event Action<BaffState> OnStateEnter;

    #endregion


    private void OnEnable()
    {
        OnStateEnter += ABaff_OnStateEnter;
    }

    private void OnDisable()
    {
        OnStateEnter -= ABaff_OnStateEnter;
    }

    private void ABaff_OnStateEnter(BaffState state)
    {
       if(baffEvents.Count > 0)
        {
            foreach (var b in baffEvents)
            {
                StartCoroutine(b.Invoke());
            }
        }
    }

    public virtual void Click()
    {
        //
    }


    protected virtual IEnumerator ActivateRoutine(float time)
    {
        yield return new WaitForSeconds(time);
    }

    protected virtual IEnumerator UsingRoutine(float time)
    {
        yield return new WaitForSeconds(time);
    }

    protected virtual IEnumerator CoolDownRoutine(float time)
    {
        yield return new WaitForSeconds(time);
    }


}
[Serializable]
public class BaffEvent
{
    [SerializeField] private BaffState currentState;
    [SerializeField] private float timeToInvoke;
    [SerializeField] private UnityEvent OnStateEnter;

    #region PROPERTIES

    public BaffState CurrentState => currentState;

    #endregion

    public IEnumerator Invoke()
    {
        yield return new WaitForSeconds(timeToInvoke);
        OnStateEnter?.Invoke();
    }
}

[Serializable]
public class BaffParams
{
    [SerializeField] private float timeToActivate;
    [SerializeField] private float activeTime;
    [SerializeField] private float coolDown;

    #region PROPERTIES

    public float TimeToActivate => timeToActivate;
    public float ActiveTime => activeTime;
    public float CoolDown => coolDown;


    #endregion


}