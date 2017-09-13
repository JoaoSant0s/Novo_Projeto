using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    [Header("CONTROLLER:")]
    [Space]

    [SerializeField]
    EnemyController control;

    [SerializeField]
    bool activedAction;

    protected bool ActivedAction
    {
        get { return activedAction; }
        set { activedAction = value; }
    }

    protected EnemyController Control
    {
        get { return control; }
    }

    internal abstract void ExecuteAction();

}
