using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroyer : MonoBehaviour
{

    [SerializeField]private ParticleSystem flame;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="ground"|| other.gameObject.tag == "portal"|| other.gameObject.tag == "teleporter" || other.gameObject.tag == "bunny")
        {
            flame.Play();
            Destroy(this.gameObject,0.05f);
        }
    }
}
