using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{

    Rigidbody rb;

    public float speed;

    float inputX, inputY;

    //jump info
    public int jumpForce;
    bool jump = false;

    //shooting
    public float bulletSpeed;
    bool shoot = false;
    public GameObject bullet;
    public Transform bulletPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true; 
        }

        if (Input.GetButtonDown("Fire1"))
        {
            shoot = true; 
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);

        //if (jump) is equal to if(jump == true)
        if (jump)
        {
            Jump();
            jump = false;
        }

        if (shoot)
        {
            Shoot();
            shoot = false;
        }
    }

    void Jump()
    {
        rb.AddForce(0, jumpForce, 0);
    }

    void Shoot()
    {
        //identity means no rotation
        GameObject bulletSpawn = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);
    }

}
