using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour 
{	
    [SerializeField]
    Animator animator;        

    internal void SetAttackState()
    {    	
    	animator.SetTrigger("attack");    	    
    }    
  
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("punch")) DestroyObject(collision.transform.parent.gameObject);
        }
    }   
}
