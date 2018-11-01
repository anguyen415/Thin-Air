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
			anim.ResetTrigger("doJump");
		else
			anim.ResetTrigger("doJump");

	}
}
