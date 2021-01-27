using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnyHealth : MonoBehaviour
{
    private int hits = 0;
    
    private void Update()
    {
        if (hits == 3)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bullet")
        {
            hits++;
        }
    }
}
