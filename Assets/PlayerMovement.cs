using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Code referenced from "Dave / GameDevelopment"
    // https://www.youtube.com/watch?v=f473C43s8nE

    [Header("Movement")]

    public float moveSpeed;
    public Transform orientation;

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
    }

    private void MovementDirection()
    {
        moveDirection = orientation.forward * yInput + orientation.right * xInput;
        playerBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
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
}
