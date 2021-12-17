using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject ShurikenPrefab;
    public int Ammocount = 15;
    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(1) && GetComponent<PlayerHealth>() != null && Ammocount > 0)
        {
            shoot();
            Ammocount -= 1;
        }

    }
    public void shoot()
    {
        Instantiate(ShurikenPrefab, firePoint.position, firePoint.rotation);
        if (firePoint1 != null)
        {
            Instantiate(ShurikenPrefab, firePoint1.position, firePoint1.rotation);
        }
        if (firePoint2 != null)
        {
            Instantiate(ShurikenPrefab, firePoint2.position, firePoint2.rotation);
        }
    }
}
