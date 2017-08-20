using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    public enum HookState
    {
        IDLE,
        LAUNCHED_HOOK,
        FIXED_HOOK,
        PUSH_HOOK
    }

    [SerializeField]
    Rigidbody2D hook_rb;

    HookState state;

    public Rigidbody2D Hook_rb
    {
        get{ return hook_rb; }
    }    

    void Start()
    {        
        state = HookState.LAUNCHED_HOOK;
    }

    internal void AddForce(Vector3 vector3, ForceMode2D force)
    {
        hook_rb.AddForce(vector3, force);
    }

    internal bool IsFixed()
    {
        return state == HookState.FIXED_HOOK;
    }    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hook_element")
        {
            hook_rb.bodyType = RigidbodyType2D.Static;
            state = HookState.FIXED_HOOK;            
        }
    }

    
}
