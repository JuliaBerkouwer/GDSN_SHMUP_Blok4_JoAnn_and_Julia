using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBtwShots = 20;
    public float bulletSpeed;
    public Transform player;
    public GameObject projectile;
    public Transform shootPoint;
    public float rotSpeed;
    public float stopPos;
    public float range;

    private float timeBtwShots;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    { 

        Vector3 relativePos = player.position - transform.position;

        if (transform.position.y < 2.9f)
            transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z);
        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            if (timeBtwShots <= 0)
            {
                GameObject go = Instantiate(projectile, transform.position, Quaternion.LookRotation(relativePos));
                go.GetComponent<Projectile>().dir = player.position - transform.position;
                go.GetComponent<Projectile>().bulletSpeed = this.bulletSpeed;
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
