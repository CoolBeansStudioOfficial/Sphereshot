using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Runtime.CompilerServices;

public class playerMovement : NetworkBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private int maxJumps;
    [SerializeField] private float maxGroundAngle;

    private int jumps;



    void Start()
    {
        if (!IsOwner)
        {
            enabled = false;
        }

        rb.bodyType = RigidbodyType2D.Dynamic;
        jumps = maxJumps;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveRpc("left");
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRpc("right");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jumps > 0)
            {
                JumpRpc();
                jumps--;
            }
        }

        CapSpeedRpc(maxSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Detects if player hits flat enough surface to count as ground
        if (Vector2.Angle(Vector2.up, collision.GetContact(0).normal) <= maxGroundAngle)
        {
            RefreshJumps();
        }
    }

    public void RefreshJumps()
    {
        jumps = maxJumps;
    }

    [Rpc(SendTo.Everyone)] 
    private void MoveRpc(string direction)
    {
        if (direction == "left")
        {
            rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
        }

        if (direction == "right")
        {
            rb.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
        }
    }

    [Rpc(SendTo.Everyone)]
    private void JumpRpc()
    {
        rb.velocityY = jumpSpeed;
    }

    [Rpc(SendTo.Everyone)]
    public void CapSpeedRpc(float speed)
    {
        if (rb.velocityX > speed)
        {  
            rb.velocityX = speed;
        }

        if (rb.velocityX < -speed)
        {
            rb.velocityX = -speed;
        }
    }

    [Rpc(SendTo.Everyone)]
    public void TeleportRpc(Vector2 location)
    {
        transform.position = location;
    }
}
