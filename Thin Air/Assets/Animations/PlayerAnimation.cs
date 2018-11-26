using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

	Animator anim;
	GameObject player;
	public float oxygen = 100f;
	public AudioSource source;
	public GameObject sounds;
	public AudioSource stepSound;

	bool dead;

	// Use this for initialization
	void Start()
	{
		anim = this.GetComponent<Animator>();
		player = GameObject.Find("Player");
		anim.SetBool("Dead", false);
		sounds = GameObject.Find("Sounds");
		stepSound = this.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			anim.SetBool("isWalking", true);
		else
			anim.SetBool("isWalking", false);

		if (Input.GetButtonDown("Jump"))
			anim.SetBool("doJump", true);
		else
			anim.SetBool("doJump", false);
		
		if (Input.GetButton("Sprint") )
			anim.SetBool("isSprinting", true);
		else
			anim.SetBool("isSprinting", false);

		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || /*Input.GetButton("Sprint") ||*/ Input.GetButtonDown("Jump"))
		{
			anim.SetBool("isMoving", true);
		}
		else
		{
			anim.SetBool("isMoving", false);
			anim.SetBool("isSprinting", false);
		}

		oxygen = player.GetComponent<Oxygen>().getCurrentOxygen();
		if (oxygen <= 0.0f)
		{
			dead = true;
			anim.SetBool("Dead", true);
		}
	}

}
