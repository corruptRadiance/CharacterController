using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    CharacterController cc; // Will probably refactor for use with a general Entity class that Controller will derive from
    void Awake()
    {
        cc = GetComponentInParent<CharacterController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        cc.IsGrounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        cc.IsGrounded = false;
    }
}
