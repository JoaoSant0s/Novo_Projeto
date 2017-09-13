using System;
using System.Collections;
using UnityEngine;

public class ActionEnemyShoot : Action
{     
    [Header("SHOOT:")]
    [Space]

    [SerializeField]
    Shoot shootPrefab;
    [SerializeField]
    float launchForce;    
    [SerializeField]
    Transform[] spawnPosition;

    IEnumerator ShootingCoroutine()
    {
        yield return new WaitForSeconds(1);

        Shooting();

        yield return new WaitForSeconds(1);
        ActivedAction = false;
    }

    void Shooting()
    {        
        var direction = (Control.Character.transform.position - transform.position);
        direction.Normalize();        

        for (int i = 0; i < spawnPosition.Length; i++)
        {               
            var shoot = Instantiate(shootPrefab, spawnPosition[i].position, Quaternion.identity);

            var directionShoot = (direction * launchForce);
            var angle = spawnPosition[i].rotation.z;

            var vector = new Vector2(directionShoot.x * Mathf.Cos(angle) - directionShoot.y * Mathf.Sin(angle), directionShoot.x * Mathf.Sin(angle) + directionShoot.y * Mathf.Cos(angle));
            shoot.ConstantForce.force = vector;
        }
    }

    internal override void ExecuteAction()
    {
        if (ActivedAction) return;
        ActivedAction = true;
        StartCoroutine(ShootingCoroutine());
    }
}
