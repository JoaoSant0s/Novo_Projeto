using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRightController : MonoBehaviour
{    
    [Header("Hook")]
    [SerializeField]
    Transform armRight;

    void Update()
    {
        /*Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - armRight.position;
        diference.Normalize();

        float rotZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;       
        armRight.rotation = Quaternion.Euler(0f, 0f, rotZ);*/
    }
}
