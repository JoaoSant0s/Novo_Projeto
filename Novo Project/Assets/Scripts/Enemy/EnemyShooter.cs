using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("CONTROLLER:")]
    [Space]

    [SerializeField]
    EnemyController control;    

    [Header("SHOOT:")]
    [Space]

    [SerializeField]
    Shoot shootPrefab;
    [SerializeField]
    float launchForce;    
    [SerializeField]
    Transform[] spawnPosition;

    private void Start()
    {       
        StartCoroutine(ShootingCoroutine());
    }

    IEnumerator ShootingCoroutine()
    {
        yield return new WaitForSeconds(1);

        Shooting();

        yield return new WaitForSeconds(2);

        StartCoroutine(ShootingCoroutine());
    }

    void Shooting()
    {        
        var direction = (control.Character.transform.position - transform.position);
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

}
