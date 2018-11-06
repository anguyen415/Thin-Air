using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkKeys : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject errorMessage;
    [SerializeField]
    private GameObject successMessage;
    [SerializeField]
    private int doorNumber;
    [SerializeField]
    private bool notOpened;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip beepsound;
    [SerializeField]
    private AudioClip errorsound;

    // Use this for initialization
    void Start () {
        notOpened = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(player.tag == "Player")
        {
            if (Input.GetButton("Interact"))
            {
                if (notOpened)
                {
                    if (player.GetComponent<PlayerKeys>().Havekey(doorNumber))
                    {
                        notOpened = false;
                        door.GetComponent<slideOpen>().unlockDoor();
                        successMessage.SetActive(true);
                        gameObject.GetComponent<displayInteract>().removeDisplay();
                        source.PlayOneShot(beepsound,  1f);
                    }
                    else
                    {
                        errorMessage.SetActive(true);
                        source.PlayOneShot(errorsound, 1f);

                    }
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (player.tag == "Player")
        {
            if (Input.GetButton("Interact"))
            {
                if (notOpened)
                {
                    if (player.GetComponent<PlayerKeys>().Havekey(doorNumber))
                    {
                        notOpened = false;
                        door.GetComponent<slideOpen>().unlockDoor();
                        successMessage.SetActive(true);
                        Destroy(gameObject.GetComponent<BoxCollider>());
                        gameObject.GetComponent<displayInteract>().removeDisplay();
                        source.PlayOneShot(beepsound,  1f);
                    }
                    else
                    {
                        errorMessage.SetActive(true);
                        source.PlayOneShot(errorsound, 1f);
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (player.tag == "Player")
        {
            errorMessage.SetActive(false);
            successMessage.SetActive(false);

        }

    }

}
