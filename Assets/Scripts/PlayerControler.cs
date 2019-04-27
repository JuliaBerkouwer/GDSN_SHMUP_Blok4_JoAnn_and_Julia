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
    private EdgeCollider2D trailCollider;
    private LineRenderer trailGraphics;
    private List<Vector2> trailGraphicsPoints = new List<Vector2>();
    private List<Vector2> trailColliderPoints = new List<Vector2>();


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trailGraphics = GetComponent<LineRenderer>();
        trailCollider = GetComponent<EdgeCollider2D>();

        timeBetweenShots = startTimeBetweenShots;
        trailGraphics.positionCount = lineLength;

        for (int i = 0; i < trailGraphics.positionCount; i++)
        {
            trailGraphics.SetPosition(i, new Vector2(transform.position.x, transform.position.y));
        }
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
        Trail();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(moveInput.x < 0)
        {   
            movingDirection = -Vector3.right;
        }
        else if(moveInput.x > 0)
        {
            movingDirection = Vector3.right;
        }

        moveVelocity = moveInput.normalized * movementSpeed;
    }

    private void Trail()
    {
        if (trailGraphicsPoints.Count == lineLength)
        {
            trailGraphicsPoints.RemoveAt(lineLength - 1);
            trailColliderPoints.RemoveAt(lineLength - 1);
        }

        Vector2 position2d = new Vector2(transform.position.x, transform.position.y);

        trailGraphicsPoints.Insert(0, position2d);
        trailColliderPoints.Insert(0, transform.InverseTransformVector(position2d));

        trailCollider.points = this.trailColliderPoints.ToArray();

        for (int i = 0; i < trailGraphicsPoints.Count; i++)
        {
            Vector3 temp = new Vector3(this.trailGraphicsPoints[i].x, this.trailGraphicsPoints[i].y, transform.position.z);
            trailGraphics.SetPosition(i, temp);
        }
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

