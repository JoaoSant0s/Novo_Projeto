using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour 
{
    [SerializeField]
    Transform target;
        
    [SerializeField]
    Vector3 offset;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }
   
	void LateUpdate () 
    {        
        transform.position = target.position + offset;
    }
}            