using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    float forceLaunch;

    [Header("Hook")]
    [SerializeField]
    Transform armRight;
    [SerializeField]
    Transform spawnHookPoint;

    [Header("Prefabs")]
    [SerializeField]
    Transform prefabHook;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        var hook = Instantiate(prefabHook, spawnHookPoint.position, armRight.rotation).GetComponent<Hook>();
        hook.AddForce(hook.transform.right * forceLaunch, ForceMode2D.Force);
    }

}
