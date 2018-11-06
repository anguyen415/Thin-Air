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

	public CharacterController controller;

	private bool Sprint;

	void Start()
	{
		BreatheAudio.Play();
	}

	void Update()
	{
		if (Input.GetButton("Sprint"))
		{
			if (Sprint == false)
				NextLevel += 1;
			Sprint = true;
		}
		else
		{
			if (Sprint == true)
				NextLevel -= 1;
			Sprint = false;
		}


		if (PrevLevel != NextLevel) //Changed Level
		{
			BreatheAudio.loop = false;
			if (!BreatheAudio.isPlaying)
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
				BreatheAudio.loop = true;
			}
		}
		if (Input.GetButtonDown("Jump") && controller.isGrounded)
			jumpAudio.Play();

		//if (!BreatheAudio.isPlaying)
		//	BreatheAudio.Play();
	}
}
