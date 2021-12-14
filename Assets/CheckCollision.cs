using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class CheckCollision : MonoBehaviour
{
    Weapon Weapon;
    public patrol Patrol;

    GameObject IsEnemyInSight;
    float shootInterval = 3f;
    float shootTime;

    // Start is called before the first frame update
    void Start()
    {
        Weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
       
       


        shootTime += Time.deltaTime;
        if (IsEnemyInSight != null && shootTime > shootInterval)
        {
            shootTime = 0f;


            Vector3 targetDirection = IsEnemyInSight.transform.position - Weapon.firePoint.position;
            Weapon.firePoint.rotation = Quaternion.LookRotation(targetDirection, Vector3.up);


            // rotate to 0 deg (reset)
            Weapon.shoot();

          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth enemy = collision.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            if (Patrol != null)
            {
                Patrol.speed = 0;
            }

            IsEnemyInSight = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerHealth enemy = collision.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            if (Patrol != null)
            {
                Patrol.speed = 4;
            }

            IsEnemyInSight = null;
        }
    }
}