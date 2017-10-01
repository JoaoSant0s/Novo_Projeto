using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour
{    
    [SerializeField]
    Punch punch;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            punch.SetAttackState();
        }
    }    
}
