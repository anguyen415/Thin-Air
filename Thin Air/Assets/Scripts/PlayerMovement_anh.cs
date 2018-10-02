using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_anh : MonoBehaviour
{
 
    private CharacterController controller;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float jumpHeight = 2f;
    [SerializeField]
    private float gravity = 9;
    private Vector3 velocity;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;

        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            velocity.y = jumpHeight;
        }
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
        

}