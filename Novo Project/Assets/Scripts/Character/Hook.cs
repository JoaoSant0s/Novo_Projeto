using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{   
    [SerializeField]
    Rigidbody2D hook_rb;

    [SerializeField]
    Animator animator;

    [SerializeField]
    GameObject particles;

    bool destroyEnemy;

    internal void AddForce(Vector3 vector3, ForceMode2D force)
    {
        destroyEnemy = true;
        hook_rb.AddForce(vector3, force);
    }   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {                          
            if (destroyEnemy) DestroyObject(collision.transform.parent.gameObject);
            PrepareToDestroy();
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("Plataform"))
        {            
            PrepareToDestroy();                                
        }        
    }

    void PrepareToDestroy()
    {
        hook_rb.bodyType = RigidbodyType2D.Static;
        DestroyObject(particles);
        animator.SetTrigger("explode");
        destroyEnemy = false;
        StartCoroutine(DestroyHook());
    }    
    
    IEnumerator DestroyHook()
    {
        yield return new WaitUntil(() => {
            return animator.GetCurrentAnimatorStateInfo(0).IsName("explode") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0);
        });

        DestroyObject(gameObject);
    }    
}
