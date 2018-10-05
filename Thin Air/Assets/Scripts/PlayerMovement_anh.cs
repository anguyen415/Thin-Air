using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_anh : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float JumpHeight;
    [SerializeField]
    private float Gravity;
    private CharacterController _controller;
    private Vector3 moveDirection;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * Speed, moveDirection.y, Input.GetAxis("Vertical") * Speed);
        if (_controller.isGrounded)
            moveDirection.y = 0f;
        if (Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
            moveDirection.y = JumpHeight;

        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * Gravity * Time.deltaTime);
        moveDirection.x *= -1;
        moveDirection.z *= -1;
        _controller.Move(moveDirection * Time.deltaTime);

    }
}

