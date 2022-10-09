using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float inputX, inputY;
    [SerializeField] float velocity, velocityMultiplier, velocityCap, deceleration;
    [SerializeField] float jumpForce, jumpCountCurrent, jumpCountMax;
    [SerializeField] bool isGrounded;
    Rigidbody2D rb;
    CapsuleCollider2D cc;

    void Start()
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
        velocity += inputX * velocityMultiplier * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, -velocityCap, velocityCap);
        transform.position += new Vector3(velocity, 0, 0) * Time.deltaTime;

        // Decelerate player when no input
        if (inputX == 0)
        {
            velocity = Mathf.Lerp(velocity, 0, deceleration) * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump")){Jump();}
    }

    void Jump()
    {
        // TODO: Implement gravity manipulation, jump higher by holding button

        // Check that jump counter is not capped
        if (jumpCountCurrent >= jumpCountMax){return;}

        // Increment jump counter, jump
        jumpCountCurrent++;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
