using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = this.GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			anim.SetBool("isWalking", true);
		else
			anim.SetBool("isWalking", false);

		if (Input.GetButtonDown("Jump"))
			anim.SetBool("doJump", true);
		else
			anim.SetBool("doJump", false);

		if (Input.GetButton("Sprint"))
			anim.SetBool("isSprinting", true);
		else
			anim.SetBool("isSprinting", false);

		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetButton("Sprint") || Input.GetButtonDown("Jump"))
			anim.SetBool("isMoving", true);
		else
			anim.SetBool("isMoving", false);

	}
}
