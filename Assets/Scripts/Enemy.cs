using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable
{

    public float moveSpeed;
    public float range;
    [Space]
    public float startTimeBtwShots = 20;
    public float bulletSpeed;

    private Transform player;
    public GameObject projectile;


    private float timeBtwShots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (transform.position.y < 2.9f)
            transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z);

        Shoot();
    }

    private void Shoot()
    {
        if (player == null) { return; }
        Vector3 direction = player.position - transform.position;

        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            if (timeBtwShots <= 0)
            {
                GameObject go = Instantiate(projectile, transform.position, Quaternion.LookRotation(direction));
                Projectile projectile1 = go.GetComponent<Projectile>();
                projectile1.dir = player.position - transform.position;
                projectile1.bulletSpeed = this.bulletSpeed;
                projectile1.whoFired = gameObject;
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
