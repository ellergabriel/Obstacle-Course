using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5;
    public float moveSpeed = 5f;
    private int jumps;
    private int maxJumps;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumps = 0;
        maxJumps = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y == 0) { jumps = 0; } //reset jumps
        if(rb.velocity.y < 0 && jumps == 0) { jumps++; } //falling off ledge, still gives second jump

        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizInput * moveSpeed, rb.velocity.y, vertInput * moveSpeed);

        if (Input.GetButtonDown("Jump") && (rb.velocity.y == 0 || jumps < maxJumps))
        {
            jumps++;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}
