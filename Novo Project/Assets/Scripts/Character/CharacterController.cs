using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour 
{

    #region Fields 
    [Header("Jump attributes")]
    [SerializeField]
    float groundRadius = 0.2f;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask whatIsGroudn;
    #endregion 

    CharacterMotor motor;
    [SerializeField]
    bool grounded = false;

    void Start() 
    {
        motor = GetComponent<CharacterMotor>();        
    }

	void FixedUpdate () 
    {        
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGroudn);
        
        motor.Move(Input.GetAxis("Horizontal"), Input.GetAxisRaw("Horizontal"));         

        if (grounded && Input.GetAxisRaw("Vertical") > 0) motor.Jump();
    }    

}
