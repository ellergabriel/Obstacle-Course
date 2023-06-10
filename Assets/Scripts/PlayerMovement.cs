using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5;
    public float moveSpeed = 5;
    private float groundCollisionDistance = .1f;
    Rigidbody rb;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizInput * moveSpeed, rb.velocity.y, vertInput * moveSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
            
        }
    }

    void Jump(){
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(other.transform.parent.gameObject);
            Jump();
        }    
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundCollisionDistance, ground);
    }
}
