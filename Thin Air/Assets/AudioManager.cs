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
<<<<<<< HEAD:Thin Air/Assets/AudioManager.cs
	public AudioSource otherAudio;
=======
	public AudioSource jumpAudio;

	public GameObject electric;
	public CharacterController controller;
>>>>>>> 726f400c23892be6592dc54b217de98bdbad8fb1:Thin Air/Assets/Scripts/AudioManager.cs

	private bool Sprint;
	private bool Camera;

	void Start()
	{
		BreatheAudio.Play();
		electric = GameObject.Find("Electric Box");
	}

	void Update()
	{
		if (Input.GetButton("Sprint") && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
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

		if (electric.GetComponent<camChange>().inGame == true)
		{
			if (Camera == false)
				NextLevel = 0;
			Camera = true;
		}
		else
		{
			if (Camera == true)
				NextLevel = 1;
			Camera = false;
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

			if(Input.GetButtonDown("Jump"))
				otherAudio.PlayOneShot(Jump1);

		}
	}
}
