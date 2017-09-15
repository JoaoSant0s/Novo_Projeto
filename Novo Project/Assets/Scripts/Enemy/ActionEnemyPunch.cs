using System;
using System.Collections;
using UnityEngine;

public class ActionEnemyPunch : Action
{
    [SerializeField]
    Animator animator;

    internal override void ExecuteAction()
    {        
        if (ActivedAction) return;
        ActivedAction = true;
        animator.SetBool("Attacking", true);

        StartCoroutine(DesactiveAttack());
    }

    private IEnumerator DesactiveAttack()
    {
        yield return new WaitUntil(() => {
            return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && animator.IsInTransition(0);
        });
        animator.SetBool("Attacking", false);
        ActivedAction = false;
    }
}
