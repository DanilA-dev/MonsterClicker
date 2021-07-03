using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawnerBaff : ABaff
{
    [SerializeField] private bool isClickable;

    #region PROPERTIES

    public override bool IsClickable { get => isClickable; set => isClickable = value; }

    #endregion 

    public override void Click()
    {
        if(isClickable && state == BaffState.Ready)
        {
            StartCoroutine(ActivateRoutine(baffParams.TimeToActivate));
        }
    }

    protected override IEnumerator ActivateRoutine(float time)
    {
        State = BaffState.Activated;
        if(state == BaffState.Activated)
        {
            yield return new WaitForSeconds(time);
            StartCoroutine(CoolDownRoutine(baffParams.ActiveTime));
        }
    }

    protected override IEnumerator UsingRoutine(float time)
    {
        State = BaffState.Activated;
        if (state == BaffState.Activated)
        {
            yield return new WaitForSeconds(time);
            StartCoroutine(CoolDownRoutine(baffParams.CoolDown));
        }
    }

    protected override IEnumerator CoolDownRoutine(float time)
    {
        State = BaffState.CoolDown;
        yield return new WaitForSeconds(time);
        State = BaffState.Ready;

    }

}

