﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour 
{
    #region Fields 
    [Header("Jump attributes")]
    [SerializeField]
    Vector3 boxSize;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask whatIsGroudn;
    #endregion 

    CharacterMotor motor;
    [SerializeField]
    bool grounded = false;

    [SerializeField]
    Animator animator;

    void Start() 
    {
        motor = GetComponent<CharacterMotor>();        
    }

	void FixedUpdate () 
    {        
        grounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, whatIsGroudn);   
                             
        var move = Input.GetAxis("Horizontal");
        var direction = Input.GetAxisRaw("Horizontal");

        motor.Move(move, direction);

        if (grounded && Input.GetButtonDown("Vertical")) motor.Jump();

        animationState(move, direction);        
    }   

    void animationState(float move, float direction)
    {
        if(!grounded){
            animator.SetBool("jumping", true);
        }else{
            animator.SetBool("jumping", false);
            if(move == 0){
                animator.SetBool("moving", false);          
            } else{
                animator.SetBool("moving", true);
            }  
        }

        if(direction != 0) 
        {
            animator.transform.localScale = new Vector3(direction * 0.5f, 0.5f, 1f);
        }
    } 

}
