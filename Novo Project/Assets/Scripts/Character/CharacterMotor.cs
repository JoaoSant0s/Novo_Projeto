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

    [SerializeField]
    Animator animator;

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

    	if(direction != 0) 
    	{
    		animator.transform.localScale = new Vector3(direction * 0.5f, 0.5f, 1f);
    	}


		if(move == 0){
	    	animator.SetBool("moving", false);        	
	    } else{
	    	animator.SetBool("moving", true);
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
