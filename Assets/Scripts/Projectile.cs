using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletImpactTime;
    [HideInInspector]
    public Vector3 dir;
    [HideInInspector]
    public GameObject whoFired;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += dir * (bulletSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, startPos) >= 10)
            DestroyProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(EdgeCollider2D)) { return; }

        if (collision.GetComponent<IDestroyable>() == null) { return; }

        if (collision.gameObject != whoFired)
        {
            Destroy(collision.gameObject);
            DestroyProjectile();
        }

    }

    private void DestroyProjectile()
    {
        // GameObject impactGO = Instantiate(impactEffectPlayer, transform.position, Quaternion.identity);
        // Destroy(impactGO, peImpactTime);
        Destroy(gameObject, bulletImpactTime);
    }
}

