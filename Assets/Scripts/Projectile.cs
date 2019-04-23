using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour {

    public float speed;
    public GameObject impactEffectPlayer;
    public float bulletImpactTime;
    public float peImpactTime; 

    private Transform player;
    private Vector3 target;
    private bool canMove = true;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(canMove)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target)  <= 0)
            DestroyProjectile();
	}
// //This below here is for resetting the scene on getting hit
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

    void DestroyProjectile()
    {

        GameObject impactGO = Instantiate(impactEffectPlayer, transform.position, Quaternion.identity);
        Destroy(impactGO, peImpactTime);
        Destroy(gameObject, bulletImpactTime);
    }
}

