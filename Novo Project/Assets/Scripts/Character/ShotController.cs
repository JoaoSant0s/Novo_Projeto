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

    [SerializeField]
    Animator animator;

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            Shot();
        }
    }

    void Shot()
    {
        if (!canShot) return;
        canShot = false;

        var direction = (animator.transform.localScale.x < 0 ? -1f : 1f);

        var newVector = new Vector3(direction, 0.1f, 1);

        var hook = Instantiate(prefabHook, spawnHookPoint.position, armRight.rotation).GetComponent<Hook>();
        hook.transform.localScale = new Vector3(hook.transform.localScale.x * direction, hook.transform.localScale.y, hook.transform.localScale.z);
        hook.AddForce(newVector * forceLaunch, ForceMode2D.Force);
        StartCoroutine(ReleaseShot());
    }

    private IEnumerator ReleaseShot()
    {
        yield return new WaitForSeconds(delayTimeShot);
        canShot = true;
    }
}
