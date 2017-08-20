using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRightController : MonoBehaviour
{
    [SerializeField]
    CharacterMotor character;

    [Header("Hook")]
    [SerializeField]
    Transform armRight;
    [SerializeField]
    Transform spawnHookPoint;

    [Header("Prefabs")]
    [SerializeField]
    Transform prefabChains;
    [SerializeField]
    Transform prefabHook;

    [Header("Variables")]
    [SerializeField]
    float forceLaunch;
    [SerializeField]
    float chainsSpawnTime;
    [SerializeField]
    float spawnCount;

    Hook hook;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(hook == null)
            {
                LaunchHook();
            }            
        }else if (Input.GetMouseButtonDown(1))
        {
            PullToHook();
        }
    }

    void PullToHook()
    {
        if (hook == null) return;

        if(hook.IsFixed())
        {
            Debug.Log("PULL");
            var direction = (hook.transform.position - character.transform.position).normalized;
            character.AddPullHook(direction);
        }
    }

    void LaunchHook()
    {
        hook = Instantiate(prefabHook, spawnHookPoint.position, armRight.rotation).GetComponent<Hook>();
        hook.AddForce(hook.transform.right * forceLaunch, ForceMode2D.Force);
        
        StartCoroutine(CreateChains());        
    }

    IEnumerator CreateChains()
    {        
        var previusConnection = hook.Hook_rb;        

        yield return new WaitForSeconds(chainsSpawnTime);

        for (int i = 0; i < spawnCount; i++)
        {
            var chain = Instantiate(prefabChains, spawnHookPoint.position, Quaternion.identity);
            var chainJoin = chain.GetComponent<DistanceJoint2D>();
            chainJoin.connectedBody = previusConnection;            
            //chain.GetComponent<HingeJoint2D>().connectedBody = previusConnection;
            previusConnection = chain.GetComponent<Rigidbody2D>();
            
            yield return new WaitForSeconds(chainsSpawnTime);
        }
        
        spawnHookPoint.GetComponent<DistanceJoint2D>().connectedBody = previusConnection;
        //spawnHookPoint.GetComponent<HingeJoint2D>().connectedBody = previusConnection;
    }

    void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - armRight.position;
        diference.Normalize();

        float rotZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;       
        armRight.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
