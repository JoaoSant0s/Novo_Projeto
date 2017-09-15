using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    float forceLaunch;
    [SerializeField]
    bool canShot;

    [Header("Hook")]
    [SerializeField]
    Transform armRight;
    [SerializeField]
    Transform spawnHookPoint;

    [Header("Prefabs")]
    [SerializeField]
    Transform prefabHook;

    [Header("Delay")]
    [SerializeField]
    float delayTimeShot;

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        if (!canShot) return;
        canShot = false;

        var hook = Instantiate(prefabHook, spawnHookPoint.position, armRight.rotation).GetComponent<Hook>();
        hook.AddForce(hook.transform.right * forceLaunch, ForceMode2D.Force);
        StartCoroutine(ReleaseShot());
    }

    private IEnumerator ReleaseShot()
    {
        yield return new WaitForSeconds(delayTimeShot);
        canShot = true;
    }
}
