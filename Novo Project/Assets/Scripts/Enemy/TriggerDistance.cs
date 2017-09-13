using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDistance : MonoBehaviour
{
    [SerializeField]
    CircleCollider2D circleCollider;

    [SerializeField]
    bool triggerFollow;

    public bool TriggerFollow
    {
        get { return triggerFollow; }
        set { triggerFollow = false; }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            circleCollider.enabled = false;
            triggerFollow = true;
        }
    }
}
