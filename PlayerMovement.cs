using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 12f;
    public float gravity = -9.81f;

    public CharacterController controller;
    public float groundDistance =0.4f;
    public Transform groundCheck;
    Vector3 velocity;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y<0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetButtonDown("Jump") && isGrounded ){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity );
        }

        controller.Move(move * speed * Time.deltaTime);
    
        velocity.y+= gravity * Time.deltaTime;
        //Add Jump mechanic based on isGrounded;
    // Debug.Log(isGrounded);
        controller.Move(velocity * Time.deltaTime);

    }
}
