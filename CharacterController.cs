using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float inputX, inputY;
    [SerializeField] float velocity, acceleration, deceleration, velocityCap;
    [SerializeField] float jumpForce, jumpCountCurrent, jumpCountMax;
    [SerializeField] bool isGrounded;
    Rigidbody2D rb;
    CapsuleCollider2D cc;
    
    public bool IsGrounded
    {
        get{return isGrounded;}
        set{isGrounded = value; if (value == true){jumpCountCurrent = 0;}
    }}

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        // Write inputs
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        // Increase velocity and incrememnt player x position by velocity
        velocity += inputX * acceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -velocityCap, velocityCap);
        transform.position += new Vector3(velocity, 0, 0) * Time.deltaTime;

        // Decelerate player when no input
        if (inputX == 0)
        {
            velocity = Mathf.MoveTowards(velocity, 0, deceleration * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump")){Jump();}
    }

    void Jump()
    {
        // Check if player can jump
        if (jumpCountCurrent >= jumpCountMax || !IsGrounded){return;}

        // Increment jump counter, jump
        jumpCountCurrent++;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
