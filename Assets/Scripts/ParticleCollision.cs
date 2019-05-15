using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour {

    public ParticleSystem particleLauncher;
    List<ParticleCollisionEvent> collisionEvents;

    //public List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    
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

