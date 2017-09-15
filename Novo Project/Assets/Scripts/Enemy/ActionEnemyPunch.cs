using System;
using System.Collections;
using UnityEngine;

public class ActionEnemyPunch : Action
{
    [SerializeField]
    Animator animator;

    internal override void ExecuteAction()
    {                           
        animator.SetTrigger("Attacking");             
    }    
}
