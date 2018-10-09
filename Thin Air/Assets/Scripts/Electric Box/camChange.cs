using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange : MonoBehaviour {
	Collider player;
	GameObject _PLAYER;
	float newZ;
	bool inGame;
	public GameObject Cam;
	public GameObject Light;
	public GameObject Cancel;
	public GameObject Interact;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player").GetComponent<Collider>();
		_PLAYER = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update ()
	{
		if(inGame ==  true)
			Interact.SetActive(false);
		if (Input.GetButtonDown("Cancel"))
			{
				_PLAYER.SetActive(true);
				GetComponent<Collider>().enabled = true;
				Cam.SetActive(false);
				Light.SetActive(false);
				inGame = false;
				Cancel.SetActive(false);
			}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other == player && Input.GetButtonDown("Interact"))
		{
			inGame = true;
			Cam.SetActive(true);
			Light.SetActive(true);
			_PLAYER.SetActive(false);
			GetComponent<Collider>().enabled = false;

			Cancel.SetActive(true);
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other == player && Input.GetButtonDown("Interact"))
		{
			inGame = true;
			Cam.SetActive(true);
			Light.SetActive(true);
			_PLAYER.SetActive(false);
			GetComponent<Collider>().enabled = false;

			Cancel.SetActive(true);
		}
	}
}
