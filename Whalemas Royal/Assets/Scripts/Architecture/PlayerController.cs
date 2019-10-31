using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int index;
    public float speed;
    public float[] grid;
    public float jumpForce = 0;
    public bool grounded;
    public int gridIndex;
    public Rigidbody rb;
    public float terminalVelocity;

    private float distToGround;

    public void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Change to make more effecient later
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Vector3 temp = rb.velocity;
            temp.y = jumpForce;
            rb.velocity = temp;
        }

        if (gridIndex > 0 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            gridIndex--;
            SwapLanes();
        }

        if (gridIndex < grid.Length-1 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            gridIndex++;                    
            SwapLanes();
        }        

        speed = rb.velocity.magnitude;
      
        SwapLanes();

        // Set X velocity to 0
        Vector3 velocity = rb.velocity;
        velocity.x = 0;        
        rb.velocity = velocity;

        // Need someway to check for collisions

        if (speed < terminalVelocity)
        {
            rb.AddForce((Time.deltaTime * 60 * Vector3.back), ForceMode.Acceleration);
        }
        else
        {
            Vector3 temp = rb.velocity;
            temp.z = -terminalVelocity;
            rb.velocity = temp;
        }
    }

    public void SwapLanes()
    {
        Vector3 temp = transform.position;
        temp.x = grid[gridIndex];
        transform.position = temp;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
