using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Code referenced from "Dave / GameDevelopment"
    // https://www.youtube.com/watch?v=f473C43s8nE

    [Header("Movement")]

    public Transform orientation;
    public float moveSpeed;
    
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultipler;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("GroundCheck")]
    public float playerHeight;
    public float drag;

    public LayerMask isGround;
    bool grounded;

    float xInput;
    float yInput;

    Vector3 moveDirection;
    Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerBody.freezeRotation = true;
        JumpReset();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGround);
        MovementInput();
        MovementSpeedControl();
        if(grounded)
            playerBody.drag = drag;
        else
            playerBody.drag = 0;
    }

    void FixedUpdate()
    {
        MovementDirection();
    }

    private void MovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(JumpReset), jumpCooldown);
        }
    }

    private void MovementDirection()
    {
        moveDirection = orientation.forward * yInput + orientation.right * xInput;
        
        if (grounded)
        {
            playerBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            playerBody.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultipler, ForceMode.Force);
        }
    }

    private void MovementSpeedControl()
    {
        Vector3 flatVelocity = new Vector3(playerBody.velocity.x, 0f, playerBody.velocity.z);
        if(flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            playerBody.velocity = new Vector3(limitedVelocity.x, playerBody.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        playerBody.velocity = new Vector3(playerBody.velocity.x, 0f, playerBody.velocity.z);
        playerBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void JumpReset()
    {
        readyToJump = true;
    }
}
