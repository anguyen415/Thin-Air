using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

	private int PrevLevel = 1;
	public int NextLevel = 1;
	public AudioClip Breath_0;
	public float lvl0_Pitch;
	public AudioClip Breath_1;
	public float lvl1_Pitch;
	public AudioClip Breath_2;
	public float lvl2_Pitch;
	public AudioClip Breath_3;
	public float lvl3_Pitch;
	public AudioClip Jump1;

	public AudioSource BreatheAudio;
	public AudioSource jumpAudio;

	public GameObject electric;
	public CharacterController controller;

	private bool Sprint;
	private bool Camera;
	private bool waitDone;
	private bool Waiting;
	private float changeTime;


	void Start()
	{
		BreatheAudio.clip = Breath_1;
		BreatheAudio.pitch = lvl1_Pitch;
		BreatheAudio.Play();
		electric = GameObject.Find("Electric Box");
		waitDone = false;
	}

	void FixedUpdate()
	{
		if (Input.GetButton("Sprint") && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
		{
			if (Sprint == false && NextLevel != 3)
				NextLevel += 1;
			if(NextLevel > 2)
				NextLevel = 2;
			Sprint = true;
		}
		else
		{
			if (Sprint == true && NextLevel != 0)
				NextLevel -= 1;
			if (NextLevel == 2)
				NextLevel -= 1;
			Sprint = false;
		}
		
		if (!Input.GetButton("Sprint") && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
		{	
			if(NextLevel == 2)
				NextLevel = 1;
		}

		if (electric.GetComponent<camChange>().inGame == true)
		{
			if (Camera == false)
				NextLevel = 0;
			Camera = true;
		}
		else
		{
//			if (Camera == true)
//				NextLevel = 1;
			Camera = false;
		}

		
		if (PrevLevel != NextLevel) //Changed Level
		{
			if(!Waiting)
				StartCoroutine(wait());
			//	BreatheAudio.loop = false;
			if (waitDone)
			{
				if (NextLevel == 0)
				{
					BreatheAudio.clip = Breath_0;
					BreatheAudio.pitch = lvl0_Pitch;
				}
				if (NextLevel == 1)
				{
					BreatheAudio.clip = Breath_1;
					BreatheAudio.pitch = lvl1_Pitch;
				}
				if (NextLevel == 2)
				{
					BreatheAudio.clip = Breath_2;
					BreatheAudio.pitch = lvl2_Pitch;
				}
				if (NextLevel == 3)
				{
					BreatheAudio.clip = Breath_3;
					BreatheAudio.pitch = lvl3_Pitch;
				}
			
				PrevLevel = NextLevel;
				BreatheAudio.Play();
				//	BreatheAudio.loop = true;
				waitDone = false;
				Waiting = false;
			}
		}
		if (Input.GetButtonDown("Jump") && controller.isGrounded)
			jumpAudio.Play();

		//if (!BreatheAudio.isPlaying)
		//	BreatheAudio.Play();
	}

	public IEnumerator wait()
	{
		if (PrevLevel > NextLevel)
			changeTime = 2.0f;
		else
			changeTime = 1.0f;

		if (NextLevel == 3)
			changeTime = 0.0f;

		Waiting = true;
		yield return new WaitForSeconds(changeTime);
		waitDone = true;
	}

}
