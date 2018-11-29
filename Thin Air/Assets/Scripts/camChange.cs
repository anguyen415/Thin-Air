using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange : MonoBehaviour {
	GameObject player;
    [SerializeField]
	GameObject model;
	float newZ;
	public bool inGame;
	public GameObject Cam;
	public GameObject Light;
	public GameObject Cancel;
	public GameObject Interact;
    public GameObject errorMessage;
    public bool needKey;

    private float prevTickRate;
	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
        prevTickRate = player.GetComponent<Oxygen>().tickRate;
    }

	// Update is called once per frame
	void Update ()
	{
		if(inGame ==  true)
            Interact.SetActive(false);
        {
            if (Input.GetButtonDown("Temp Cancel"))
            {
                player.GetComponent<PlayerMovement_anh>().enabled = true;
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<Oxygen>().tickRate = prevTickRate;
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
        if (player.GetComponent<PlayerKeys>().Havekey(4) || !needKey)
        {

            if (other == player.GetComponent<Collider>() && Input.GetButtonDown("Interact"))
            {
                player.GetComponent<PlayerMovement_anh>().enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<Oxygen>().tickRate = prevTickRate * 2;
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
        if (player.GetComponent<PlayerKeys>().Havekey(4) || !needKey)
        {

            if (other == player.GetComponent<Collider>() && Input.GetButtonDown("Interact"))
            {
                player.GetComponent<PlayerMovement_anh>().enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<Oxygen>().tickRate = prevTickRate * 2;
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
