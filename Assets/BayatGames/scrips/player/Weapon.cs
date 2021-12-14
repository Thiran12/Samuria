using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ShurikenPrefab;
    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(1) && GetComponent<PlayerHealth>() != null )
        {
            shoot();
        }

    }
    public void shoot()
    {
        Instantiate(ShurikenPrefab, firePoint.position, firePoint.rotation);
    }
}
