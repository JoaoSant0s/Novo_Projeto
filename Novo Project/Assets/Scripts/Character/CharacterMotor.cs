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
    #endregion

    #region Components    
    Rigidbody2D rg;
    #endregion    

    bool facingRight = true;    
    void Awake() 
    {
        rg = GetComponent<Rigidbody2D>();
    }

    internal void Move(float move, float direction) 
    {    	
        if(move != 0) 
        {        	
        	rg.velocity = new Vector2(move * Time.fixedDeltaTime * maxSpeend, rg.velocity.y);        	        
    	}    	
    }

    internal void Jump() 
    {
        rg.AddForce(new Vector2(0, jumpForce));        
    }

    internal void Boost(Vector3 force)
    {        
        rg.AddForce(force, ForceMode2D.Force);
    }
}
