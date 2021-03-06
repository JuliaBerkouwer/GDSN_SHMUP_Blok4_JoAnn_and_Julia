﻿using UnityEngine;

public class Projectile : MonoBehaviour, IDestroyable
{
    public float bulletImpactTime;
    private float bulletSpeed;
    private Vector3 direction;
    private GameObject whoFired;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position += direction * (bulletSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, startPos) >= 10)
            DestroyProjectile();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDestroyable>() == null) { return; }

        if (collision.gameObject == whoFired) { return; }

        Destroy(collision.gameObject);
        DestroyProjectile();
    }

    public void setupBullet(Vector3 direction, float bulletSpeed, GameObject whoFired)
    {
        this.direction = direction.normalized;
        this.bulletSpeed = bulletSpeed;
        this.whoFired = whoFired;
    }

    private void DestroyProjectile()
    {
        // GameObject impactGO = Instantiate(impactEffectPlayer, transform.position, Quaternion.identity);
        // Destroy(impactGO, peImpactTime);
        Destroy(gameObject, bulletImpactTime);
    }
}