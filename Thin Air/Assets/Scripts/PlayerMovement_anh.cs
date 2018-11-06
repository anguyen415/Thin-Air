using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_anh : MonoBehaviour
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
    private bool isWallJump;
    private Vector3 normal;
    [SerializeField]
    private float walljumpSpeed;
    [SerializeField]
    private float walljumpRotate;
    private bool initWallJump;
    private int mask = 1 << 9;

	//Jon
	[SerializeField]
	private bool Sprint;
	private float moveRate = 1.0f;
	public float sprintScale = 1.5f;

	private void Start()
    {
        _controller = GetComponent<CharacterController>();
        isWallJump = false;
        initWallJump = false;
		Sprint = false;//Jon
        mask = ~mask;
    }

    private void Update()
    {

		if (isWallJump)
		{
			if (initWallJump && ((Input.GetAxis("Horizontal") * normal.x) < 0))
			{
				moveDirection = new Vector3(0, 0, 0);
				moveDirection.y = moveDirection.y + (Physics.gravity.y * Gravity * Time.deltaTime);
				_controller.Move(moveDirection * Time.deltaTime);
				if (Input.GetButtonDown("Jump"))
				{
					moveDirection.y = JumpHeight;
					initWallJump = false;
				}

			}
			else
			{
				moveDirection = new Vector3(normal.x * walljumpSpeed, moveDirection.y, normal.z * walljumpSpeed);
				moveDirection.y = moveDirection.y + (Physics.gravity.y * Gravity * Time.deltaTime);
				Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
				playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, walljumpRotate * Time.deltaTime);
				_controller.Move(moveDirection * Time.deltaTime);

                if(isGrounded())
 
				{
					isWallJump = false;
					initWallJump = false;

				}

			}
		}
		else
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal") * Speed * moveRate, moveDirection.y, Input.GetAxis("Vertical") * Speed * moveRate);
			float yStorage = moveDirection.y;

			if (_controller.isGrounded)
			{
				moveDirection.y = 0f;
				if (Input.GetButtonDown("Jump"))
				{
					moveDirection.y = JumpHeight;
				}
			}

			if (Input.GetButton("Sprint"))
				Sprint = true;
			else
				Sprint = false;
			if (Sprint == true)
				moveRate = sprintScale;
			else
				moveRate = 1.0f;

			moveDirection.y = moveDirection.y + (Physics.gravity.y * Gravity * Time.deltaTime);

			if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			{
				//transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
				Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
				playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
			}
			if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
				_controller.Move(moveDirection * DiagonalScale * Time.deltaTime);
			else
				_controller.Move(moveDirection * Time.deltaTime);
		}

	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (isWallJump)
        {

            initWallJump = true;
        }
        if (hit.gameObject.tag == "Wall")
        {
            normal = hit.normal;
            if (!_controller.isGrounded && hit.normal.y != 0)
            {
                //Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);

                if (Input.GetButtonDown("Jump"))
                {
                    //  Debu5g.DrawRay(hit.point, hit.normal, Color.yellow, 1.25f);
                    moveDirection.y = JumpHeight;
                    isWallJump = true;

                }
            }
        }
    }

    public bool isGrounded()
    {
        //get the radius of the players capsule collider, and make it a tiny bit smaller than that
        float radius = _controller.radius * 0.9f;
        //get the position (assuming its right at the bottom) and move it up by almost the whole radius
        Vector3 pos = transform.position + Vector3.down * 3.6f;
        //returns true if the sphere touches something on that layer
        return (Physics.CheckSphere(pos, radius, mask, QueryTriggerInteraction.Ignore));
    }
}

