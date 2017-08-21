using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shot")
        {
            DestroyObject(collision.gameObject);
            DestroyObject(gameObject);
        }
    }
}
