using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Jon : MonoBehaviour
{
	[SerializeField]
	private float DiagonalScale;
	[SerializeField]
	private float Speed;
	[SerializeField]
	private float JumpHeight;
	[SerializeField]
	private float Gravity;
	private CharacterController _controller;
	private Vector3 moveDirection;
	[SerializeField]
	private float rotateSpeed;
	[SerializeField]
	private Transform pivot;
	[SerializeField]
	private GameObject playerModel;

	[SerializeField]
	private bool Sprint;
	private float moveRate = 1.0f;


	private void Start()
	{
		_controller = GetComponent<CharacterController>();
		Sprint = false;
	}

	private void Update()
	{
		moveDirection = new Vector3(Input.GetAxis("Horizontal") * Speed, moveDirection.y, Input.GetAxis("Vertical") * Speed);
		/* moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
		 moveDirection = moveDirection.normalized * Speed;
		 moveDirection.y = yStorage;*/
		moveDirection = new Vector3(Input.GetAxis("Horizontal") * Speed * moveRate, moveDirection.y, Input.GetAxis("Vertical") * Speed * moveRate);
		float yStorage = moveDirection.y;

		if (_controller.isGrounded)
		{
			moveDirection.y = 0f;
			if (Input.GetButtonDown("Jump"))
			{
				Sprint = true;
				moveDirection.y = JumpHeight;
			}
			Sprint = false;
		}

		if (Input.GetButton("Sprint"))
			Sprint = true;
		else
			Sprint = false;
		if (Sprint == true)
			moveRate = 1.5f;
		else
			moveRate = 1.0f;
	
		moveDirection.y = moveDirection.y + (Physics.gravity.y * Gravity * Time.deltaTime);

		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			//transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
			Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
			playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
		}
		if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
			_controller.Move(moveDirection * DiagonalScale * Time.deltaTime);
		else
			_controller.Move(moveDirection * Time.deltaTime);


	}
}
