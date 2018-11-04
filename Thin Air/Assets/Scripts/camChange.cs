using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange : MonoBehaviour {
	GameObject player;
    [SerializeField]
	GameObject model;
	float newZ;
	bool inGame;
	public GameObject Cam;
	public GameObject Light;
	public GameObject Cancel;
	public GameObject Interact;
    public GameObject errorMessage;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");

    }

	// Update is called once per frame
	void Update ()
	{
		if(inGame ==  true)
            Interact.SetActive(false);
        {
            if (Input.GetButtonDown("Temp Cancel"))
            {
                player.GetComponent<PlayerMovement_Jon>().enabled = true;
                player.GetComponent<CharacterController>().enabled = true;
                GetComponent<Collider>().enabled = true;
                model.SetActive(true);
                Cam.SetActive(false);
                Light.SetActive(false);
                inGame = false;
                Cancel.SetActive(false);
            }
        }
	}
	void OnTriggerEnter(Collider other)
	{
        if (player.GetComponent<PlayerKeys>().Havekey(4))
        {

            if (other == player.GetComponent<Collider>() && Input.GetButtonDown("Interact"))
            {
                player.GetComponent<PlayerMovement_Jon>().enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                model.SetActive(false);
                inGame = true;
                Cam.SetActive(true);
                Light.SetActive(true);
                GetComponent<Collider>().enabled = false;
                Cancel.SetActive(true);
            }
        }
        else
        {
            errorMessage.SetActive(true);
        }
    }
	void OnTriggerStay(Collider other)
    {
        if (player.GetComponent<PlayerKeys>().Havekey(4))
        {

            if (other == player.GetComponent<Collider>() && Input.GetButtonDown("Interact"))
            {
                player.GetComponent<PlayerMovement_Jon>().enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                model.SetActive(false);
                inGame = true;
                Cam.SetActive(true);
                Light.SetActive(true);
                GetComponent<Collider>().enabled = false;
                Cancel.SetActive(true);
            }
        }
        else
        {
            errorMessage.SetActive(true);
        }
	}
    void OnTriggerExit(Collider other)
    {
        errorMessage.SetActive(false);
    }
}
