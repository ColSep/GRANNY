using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class BossScript : MonoBehaviour
{
    public static int bosshp = 10;

    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
    }

    void Update()
    {
        if (Random.Range(0, 100) == 5)
        {
            Shoot();
        }
    }


    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}