using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public CharacterController controller;
    private float speed;
    public float walkSpeed = 12f;
    public float crouchSpeed = 8f;
    public float jumpHeight = 3f;

    [Header("Physics")]
    private Vector3 velocity;
    public float gravity = -9.81f; //wow gravitational field strength

    [Header("Jumps")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    [Header("Crouch")]
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;
    private bool isCrouching;

    void Start()
    {
        playerScale = transform.localScale;
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //jump and gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            isCrouching = true;
            speed = crouchSpeed;
            transform.localScale = crouchScale;
            transform.position = new Vector3(transform.position.x, transform.position.y - .4f, transform.position.z);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            speed = walkSpeed;
            transform.localScale = playerScale;
            //transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z); //idk but off
        }

        //movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //wow phy equation
        }


        //final velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}