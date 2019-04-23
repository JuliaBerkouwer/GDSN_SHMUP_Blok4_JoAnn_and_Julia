using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // public float moveSpeed;
    // public float jumpSpeed;
    // public float gravity;
    // public GameObject trailfx;

    // public KeyCode shootKey = KeyCode.C;
    // public KeyCode upKey = KeyCode.W;
    // public KeyCode downKey = KeyCode.S;
    // public KeyCode rightKey = KeyCode.D;
    // public KeyCode leftKey = KeyCode.A;

    // void Update()
    // {
    //     if (Input.GetKey(rightKey))
    //     {
    //         transform.position += Vector3.right * moveSpeed;
    //     }

    //     if (Input.GetKey(leftKey))
    //     {
    //         transform.position += Vector3.left * moveSpeed;
    //     }

    //     if (Input.GetKey(upKey))
    //     {
    //         transform.position += Vector3.up * moveSpeed;
    //     }

    //     if (Input.GetKey(downKey))
    //     {
    //         transform.position += Vector3.down * moveSpeed;
    //     }
    // }

    public float speed;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float startTimeBtwShots = 20;
    private float timeBtwShots;
    public GameObject projectile;
    public Transform shootPoint;

    public KeyCode shootKey = KeyCode.C;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        Vector3 relativePos = player.position - transform.position;

        if (Input.GetKey(shootKey))
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

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}

