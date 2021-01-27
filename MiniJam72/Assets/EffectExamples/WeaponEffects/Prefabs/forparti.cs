using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forparti : MonoBehaviour
{

    public ParticleSystem particleLauncher;
    public ParticleSystem splatterParticles;
   // public Gradient particleColorGradient;
  //  public ParticleDecalPool splatDecalPool;

    List<ParticleCollisionEvent> collisionEvents;
  

    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    IEnumerator ExampleCoroutine(ParticleSystem particleLauncher)
    {
        //Print the time of when the function is first called.
        particleLauncher.Emit(1);

        yield return new WaitForSeconds(1f);

    }

    //yield on a new YieldInstruction that waits for 5 seconds.

    //After we have waited 5 seconds print the time again.



void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
           // splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
            EmitAtLocation(collisionEvents[i]);
        }

    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        splatterParticles.transform.position = particleCollisionEvent.intersection;
        splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
        //ParticleSystem.MainModule psMain = splatterParticles.main;
       // psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

        splatterParticles.Emit(1);
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            // ParticleSystem.MainModule psMain = particleLauncher.main;
            // psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
            StartCoroutine(ExampleCoroutine(particleLauncher));
        }

    }
}