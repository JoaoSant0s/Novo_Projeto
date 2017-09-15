using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{   
    [SerializeField]
    Rigidbody2D hook_rb;

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
            if(destroyEnemy) DestroyObject(collision.transform.parent.gameObject);
            DestroyObject(gameObject);
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("Plataform"))
        {
            destroyEnemy = false;
            StartCoroutine(GameObjectDestroyer());        
        }
    }    

    IEnumerator GameObjectDestroyer()
    {
        yield return new WaitForSeconds(0.5f);
        DestroyObject(gameObject);
    }
}
