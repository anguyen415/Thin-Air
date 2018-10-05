using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private bool _useFixedUpdateForInput = false;

    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private float verticalVelocity;
    [SerializeField]
    private float gravity = 14.0f;
    [SerializeField]
    private float jumpForce = 10.0f;


    private static float HorizontalInput
    {
        get { return Input.GetAxis("Horizontal"); }
    }

    private static float VerticalInput
    {
        get { return Input.GetAxis("Vertical"); }
    }

    private static Vector3 UserInput
    {
        get { return new Vector3(HorizontalInput, VerticalInput, -3.0f); }
    }

    private Vector3 _inputDirection;
    //private Rigidbody _rigidBody;

    private void Awake()
    {
        //_rigidBody = GetComponentInChildren<Rigidbody>();
        controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
        if (!_useFixedUpdateForInput)
        {
            _inputDirection = UserInput;
        }
    }

    private void FixedUpdate()
    {
        if (_useFixedUpdateForInput)
        {
            _inputDirection = UserInput;
        }
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        //_rigidBody.velocity = new Vector3(_inputDirection.x, 0.0f, _inputDirection.y) * _speed;
        Vector3 moveVector = Vector3.zero;
        moveVector.x = HorizontalInput;
        moveVector.y = verticalVelocity;
        moveVector.z = VerticalInput;
        //new Vector3(HorizontalInput, verticalVelocity, VerticalInput);
        controller.Move(moveVector * Time.deltaTime);
        
    }

}
