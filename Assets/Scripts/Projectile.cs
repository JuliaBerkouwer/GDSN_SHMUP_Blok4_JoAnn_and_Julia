using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour {

    public float bulletSpeed;
    // public GameObject impactEffectPlayer;
    public float bulletImpactTime;
    public float peImpactTime; 

    private Vector3 target;
    public Vector3 dir;
    private Vector3 startPos;

	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        startPos = transform.position;
    }
	
	void Update ()
    {
        // transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position += dir * (bulletSpeed * Time.deltaTime);
        float dist = Vector3.Distance(transform.position, target);
        if (dist  <= 0 || Vector3.Distance(transform.position,startPos) >= 10)
            DestroyProjectile();
	}
//This below here is for resetting the scene on getting hit
//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//         }
//         else if (!other.CompareTag("Police"))
//         {
//             DestroyProjectile();
//             canMove = false;
//         }
//     }

    private void DestroyProjectile()
    {
        // GameObject impactGO = Instantiate(impactEffectPlayer, transform.position, Quaternion.identity);
        // Destroy(impactGO, peImpactTime);
        Destroy(gameObject, bulletImpactTime);
    }
}

