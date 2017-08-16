using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRightController : MonoBehaviour
{
    [SerializeField]
    Transform armRight;
    [SerializeField]
    Transform spawnHookPoint;

    [SerializeField]
    Transform prefabHook;

    [SerializeField]
    float forceLaunch;

    public enum HookState {
        IDLE,
        LAUNCHED_HOOK,
        FIXED_HOOK,
        PUSH_HOOK
    }

    HookState state;

    void Start()
    {
        state = HookState.IDLE;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (state)
            {
                case HookState.IDLE:
                    //state = HookState.LAUNCHED_HOOK;
                    var hook = Instantiate(prefabHook, spawnHookPoint.position, armRight.rotation).GetComponent<Rigidbody2D>();
                    Debug.Log(hook.transform.up);
                    Debug.Log(hook.transform.forward);
                    Debug.Log(hook.transform.right);                    
                    hook.AddForce(hook.transform.right * forceLaunch, ForceMode2D.Force);                   

                    break;                
                default:
                    break;
            }
        }else if (Input.GetMouseButtonDown(1))
        {
            switch (state)
            {                
                case HookState.LAUNCHED_HOOK:
                    state = HookState.PUSH_HOOK;
                    break;
                case HookState.FIXED_HOOK:
                    state = HookState.PUSH_HOOK;
                    break;
                default:
                    break;
            }

        }
    }

    void Update()
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - armRight.position;
        diference.Normalize();

        float rotZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;       
        armRight.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
