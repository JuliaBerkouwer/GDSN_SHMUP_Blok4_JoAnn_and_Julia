using UnityEngine;
using System.Collections.Generic;

public class PlayerControler : MonoBehaviour, IDestroyable
{
    public float movementSpeed;
    [Space]
    public int lineLength;
    [Space]
    public GameObject projectile;
    public float bulletSpeed;
    public float startTimeBetweenShots = 20;
    public KeyCode shootKey = KeyCode.C;

    private Vector3 movingDirection = Vector3.right;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float timeBetweenShots;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        timeBetweenShots = startTimeBetweenShots;
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        BetweenShotsTimer();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (moveInput.x < 0)
        {
            movingDirection = -Vector3.right;
        }
        else if (moveInput.x > 0)
        {
            movingDirection = Vector3.right;
        }

        moveVelocity = moveInput.normalized * movementSpeed;
    }

    private void Shoot()
    {
        if (!projectile)
        {
            Debug.LogWarning("The is no projectile");
            return;
        }

        if (Input.GetKey(shootKey))
        {
            if (canShoot)
            {
                GameObject go = Instantiate(projectile, transform.position, Quaternion.identity);

                Projectile projectile1 = go.GetComponent<Projectile>();
                projectile1.setupBullet(movingDirection, bulletSpeed, gameObject);

                timeBetweenShots = startTimeBetweenShots;
                canShoot = false;
            }
        }
    }

    private void BetweenShotsTimer()
    {
        if (timeBetweenShots <= 0)
        {
            canShoot = true;
        }
        else
        {
            timeBetweenShots -= Time.fixedDeltaTime;
        }
    }
}

