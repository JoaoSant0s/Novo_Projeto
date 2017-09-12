using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    float forcePullToHook;

    [Header("References")]
    [SerializeField]
    CharacterMotor character;
    [SerializeField]
    Transform armRight;    

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shot();
        }
    }

    void Shot()
    {
        character.Boost(armRight.transform.right * forcePullToHook);      
    }
}
