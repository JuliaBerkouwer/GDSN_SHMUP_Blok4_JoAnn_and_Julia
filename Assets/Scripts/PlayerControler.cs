using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float speed;
    public Transform player;
    private Rigidbody rb;
    public float bulletSpeed;
    private Vector3 moveVelocity;
    public float startTimeBtwShots = 20;
    private float timeBtwShots;
    public GameObject projectile;
    public Transform shootPoint;

    public KeyCode shootKey = KeyCode.C;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),transform.position.z);
        moveVelocity = moveInput.normalized * speed;

        Vector3 relativePos = player.position - transform.position;

        if (Input.GetKey(shootKey))
        {
            if(canShoot)
            {
                GameObject go = Instantiate(projectile, transform.position, Quaternion.LookRotation(relativePos));
                go.GetComponent<Projectile>().dir = Vector3.right;
                go.GetComponent<Projectile>().bulletSpeed = this.bulletSpeed;
                timeBtwShots = startTimeBtwShots;
                canShoot = false;
            }

            if (timeBtwShots <= 0)
            {
                canShoot = true;
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

