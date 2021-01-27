using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
     [SerializeField] private Rigidbody brb;
    [SerializeField] private float force = 10f;
    [SerializeField] private float sideForce = 10f;
    [SerializeField] private float sign;
     [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform spawn;
    private bool isflipped;
    private float offset;
    private int filppedsign=1;
    private float shootspeed=10;
    private Rigidbody bulrb;
    private float Sign=-1;
   // [SerializeField] private Transform teleport;
    [SerializeField] private Transform teleport2;
    private float gravity = -70;
    private string currentAnimaton;
    private bool grounded;

    private const string idle = "Idle";
    private const string run = "Running";
    // Start is called before the first frame update
    private void Start()
    {
       
        grounded = ground.GetComponent<groundDetector>().isGrounded;
    }
    // Update is called once per frame
    void Update()
    {
        if (isflipped)
        {
            offset = 180;
            filppedsign = -1;
        }
        if (!isflipped)
        {
            offset = 0;
            filppedsign = 1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
           
        }

        grounded = ground.GetComponent<groundDetector>().isGrounded;
        //transform.Translate(Vector3.up * -speed * 5 * Time.deltaTime, Space.World);
        if (!grounded)
        {
            brb.AddForce(0, gravity, 0, ForceMode.Acceleration);
            ChangeAnimationState(run);
            currentAnimaton = run;
        }

        if (Input.GetKey("d"))
        {
            if (Input.GetKeyDown("d"))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x+offset, 115*filppedsign, transform.rotation.z);
            }
            Sign = 1;
            transform.Translate(Vector3.right * speed * Time.deltaTime,Space.World);
            
            ChangeAnimationState(run);
            currentAnimaton = run;
            
           
        }
       else if (Input.GetKey("a"))
        {
            if (Input.GetKeyDown("a"))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x+offset, 235*filppedsign, transform.rotation.z);
                
            }
            Sign = -1;
            transform.Translate(Vector3.right * -speed * Time.deltaTime, Space.World);
            ChangeAnimationState(run);
            currentAnimaton = run;

        }
       
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            
            brb.AddForce(0f,force*filppedsign,0f,ForceMode.Impulse);
            ChangeAnimationState(run);
            currentAnimaton = run;
        }

        if(grounded && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            
            ChangeAnimationState(idle);
            currentAnimaton = idle;
        }

              
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "portal")
        {
            Vector3 temp = transform.position;

            transform.position = Vector3.Lerp(temp, spawn.position,100);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 115, transform.rotation.z);
            gravity = -70;
            isflipped = false;
        }

        
        if (other.gameObject.tag == "teleport2")
        {
            Vector3 temp = transform.position;

            transform.position = Vector3.Lerp(temp, teleport2.position, 100);
            transform.rotation = Quaternion.Euler(180,transform.rotation.y, transform.rotation.z);
            gravity = 70;
            isflipped = true;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bunny")
            
        {
            Vector3 temp = transform.position;
            transform.position = Vector3.Lerp(temp, spawn.position, 100);
            transform.rotation = Quaternion.Euler(transform.rotation.x, 115, transform.rotation.z);
            gravity = -70;
            isflipped = false;
        }
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    private void Shoot()
    {
      GameObject temp=  Instantiate(bullet, shootPoint.position,shootPoint.rotation);
       temp.GetComponent<Rigidbody>().AddForce(shootspeed*6*Sign,0,0,ForceMode.Impulse);
        
    }
}
