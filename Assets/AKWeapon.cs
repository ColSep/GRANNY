using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && GetComponent<Animator>().GetBool("isInRussia"))
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
