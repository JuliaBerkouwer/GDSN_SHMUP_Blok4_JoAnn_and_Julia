using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour {

    public ParticleSystem particleLauncher;
    List<ParticleCollisionEvent> collisionEvents;

    void Start () 
    {
        collisionEvents = new List<ParticleCollisionEvent> ();
    }

    void OnParticleCollision(GameObject collision)
    {
        ParticlePhysicsExtensions.GetCollisionEvents (particleLauncher, collision, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++) 
        {
            Destroy(collision.gameObject);
        }

    }

}

