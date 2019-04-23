using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBtwShots = 20;
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
        Vector3 direction = player.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
        transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, transform.rotation.w);

        Vector3 relativePos = player.position - transform.position;

        if (transform.position.y < 2.9f)
            transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z);
        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, shootPoint.position, Quaternion.LookRotation(relativePos));
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

    }
}
