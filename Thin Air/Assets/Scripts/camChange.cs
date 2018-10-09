using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange : MonoBehaviour {
	GameObject player;
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
		player = GameObject.Find("Player");
		_PLAYER = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update ()
	{
		if(inGame ==  true)
			Interact.SetActive(false);
		if (Input.GetButtonDown("Temp Cancel"))
			{
				_PLAYER.SetActive(true);
			player.GetComponent<CharacterController>().enabled = true;
			GetComponent<Collider>().enabled = true;
			GetComponent<MeshCollider>().enabled = true;
			Cam.SetActive(false);
				Light.SetActive(false);
				inGame = false;
				Cancel.SetActive(false);
			}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other == player.GetComponent<Collider>() && Input.GetButtonDown("Interact"))
		{
			player.GetComponent<CharacterController>().enabled = false;

			inGame = true;
			Cam.SetActive(true);
			Light.SetActive(true);
<<<<<<< HEAD:Thin Air/Assets/Scripts/Electric Box/camChange.cs
            _PLAYER.GetComponent<PlayerMovement_anh>().enabled = false;
            GetComponent<Collider>().enabled = false;
=======
			_PLAYER.SetActive(false);
			GetComponent<Collider>().enabled = false;
			GetComponent<MeshCollider>().enabled = false;
>>>>>>> f6abda6a4363f528b67dfc5c9eeb141974e06281:Thin Air/Assets/Scripts/camChange.cs

			Cancel.SetActive(true);
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other == player.GetComponent<Collider>() && Input.GetButtonDown("Interact"))
		{
			player.GetComponent<CharacterController>().enabled = false;

			inGame = true;
			Cam.SetActive(true);
			Light.SetActive(true);
			_PLAYER.GetComponent<PlayerMovement_anh>().enabled = false;
			GetComponent<Collider>().enabled = false;
			GetComponent<MeshCollider>().enabled = false;

			Cancel.SetActive(true);
		}
	}
}
