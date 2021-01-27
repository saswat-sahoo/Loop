using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField] private Rigidbody brb;
    [SerializeField] private float force = 10f;
    [SerializeField] private float sideForce = 10f;
    [SerializeField] private float sign;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            sign = 1f;
            transform.rotation= Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
       else if (Input.GetKey("a"))
        {
            sign = -1f;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 230, transform.rotation.z);
        }
       
        else
        {
            sign = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
           
            brb.AddForce(sideForce*sign,force,0f,ForceMode.Impulse);
        }
    }

    private int rng()
    {
        int c=0;
        if (Random.Range(0, 2) < 1)
        {
            c = -1;
        }
        else
        {
            c = 1;
        }
        return c;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = false;
        }
    }
}
