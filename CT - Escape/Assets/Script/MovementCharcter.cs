using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharcter : MonoBehaviour
{
    private CharacterController controller;


    public float speed;

    public float gravity = -500f;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Final()
    {
        //speed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded == false && velocity.y < 0)
        {
            velocity.y = -200f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        //velocity.y = 0;

        controller.Move(velocity * Time.deltaTime);

        if(lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        } 
        else 
        {
            isMoving = false;
        }

        lastPosition = gameObject.transform.position;

    }

}
