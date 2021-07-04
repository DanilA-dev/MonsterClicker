using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class DisableSpawnerBaff : ABaff
{
    [SerializeField] private bool isClickable;
    [SerializeField] List<SimpleTweenAnimation> animations = new List<SimpleTweenAnimation>();

    #region PROPERTIES

    public override bool IsClickable { get => isClickable; set => isClickable = value; }

    #endregion

    #region EVENTS

    public static event Action<bool> OnSpawnerDisable;

    #endregion


    private void Start()
    {
        if(animations.Count > 0)
        {
            foreach (var a in animations)
            {
                a.Animate();
            }
        }    
    }


    public override void OnMouseDown()
    {
        Click();
    }


    public override void Click()
    {
        if (isClickable && state == BaffState.Ready)
        {
            StartCoroutine(ActivateRoutine(baffParams.TimeToActivate));
        }
    }

    protected override IEnumerator ActivateRoutine(float time)
    {
        State = BaffState.Activated;
        if (state == BaffState.Activated)
        {
            yield return new WaitForSeconds(time);
            OnSpawnerDisable?.Invoke(true);
            StartCoroutine(UsingRoutine(baffParams.ActiveTime));
        }
    }

    protected override IEnumerator UsingRoutine(float time)
    {
        State = BaffState.Activated;
        if (state == BaffState.Activated)
        {
            yield return new WaitForSeconds(time);
            OnSpawnerDisable?.Invoke(false);
            State = BaffState.Ready;
            this.gameObject.SetActive(false);
        }
    }

   

    
}

