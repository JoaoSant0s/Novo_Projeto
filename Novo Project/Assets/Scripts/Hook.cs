using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{   
    [SerializeField]
    Rigidbody2D hook_rb;    

    internal void AddForce(Vector3 vector3, ForceMode2D force)
    {
        hook_rb.AddForce(vector3, force);
    }   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hook_element")
        {
                     
        }
    }    
}
