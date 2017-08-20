using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour 
{    
    #region Fields    
    [SerializeField]
    float jumpForce = 350f;
    [SerializeField]
    float maxSpeend = 20f;    
    [SerializeField]
    Transform graphic;
    [SerializeField]
    float forcePullToHook;
    #endregion

    #region Components    
    Rigidbody2D rg;
    #endregion    

    bool facingRight = true;
    void Awake() 
    {
        rg = GetComponent<Rigidbody2D>();
    }

    internal void Move(float move) 
    {
        if(move != 0) rg.velocity = new Vector2(move * maxSpeend, rg.velocity.y);        
        graphic.Rotate(0, 0, -(rg.velocity.x) /*/ 60 * 360 * Time.deltaTime*/);        
    }

    internal void Jump() 
    {
        rg.AddForce(new Vector2(0, jumpForce));        
    }

    internal void AddPullHook(Vector3 direction)
    {        
        rg.AddForce(direction * forcePullToHook, ForceMode2D.Force);
    }
}
