using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float bulletSpeed = 5f;

    private float nextFireTime;
    private Transform player;

    public Transform target; // 向きたい対象の Transform
    public bool flipX = false; // 左右反転が必要かどうか



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }


        if (target != null)
        {

            Vector3 direction = target.position - transform.position;


            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 135;


            if (flipX)
            {
                angle += 180f;
            }


            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }
}