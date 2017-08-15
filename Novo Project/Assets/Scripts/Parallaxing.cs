﻿using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour 
{
    #region Fields
    [SerializeField]
    Transform[] backgrounds;
    [SerializeField]
    public float smoothing = 1f;
    #endregion

    float[] parallaxScales;    
    Transform cam;
    Vector3 previousCamPos;
    
    void Awake() 
    {        
        cam = Camera.main.transform;
    }
    
    void Start() 
    {    
        previousCamPos = cam.position;
     
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++) 
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }
    
    void Update() 
    {        
        for (int i = 0; i < backgrounds.Length; i++) 
        {            
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
        
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}
