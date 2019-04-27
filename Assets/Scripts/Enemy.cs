using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable
{

    public float range;
    [Space]
    public float startTimeBtwShots = 20;
    public float bulletSpeed;
    public GameObject projectile;

    private Transform player;
    private float timeBtwShots;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (player == null) { return; }
        Vector3 lookDirection = player.position - transform.position;

        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            if (timeBtwShots <= 0)
            {
                GameObject go = Instantiate(projectile, transform.position, Quaternion.LookRotation(lookDirection));

                Projectile projectile1 = go.GetComponent<Projectile>();
                Vector3 shootDirection = player.position - transform.position;
                projectile1.setupBullet(shootDirection,bulletSpeed, gameObject);

                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
