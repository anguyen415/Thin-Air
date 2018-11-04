using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour {
    private bool PlayerinRange = false;
    [SerializeField]
    GameObject interactableObject;
    [SerializeField]
    GameObject player;
    [SerializeField]
    private GameObject Cancel;
    [SerializeField]
    private GameObject Interact;
    [SerializeField]
    private bool press = false;

    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update() {
        if (PlayerinRange) {
            if (!press) 
                Interact.SetActive(true);
            if (Input.GetButtonDown("Interact")){
                press = true;
                Interact.SetActive(false);
                Cancel.SetActive(true);
                interactableObject.SetActive(true);
                player.GetComponent<PlayerMovement_Jon>().enabled = false;
            }
            else if (Input.GetButtonDown("Temp Cancel")){
                interactableObject.SetActive(false);
                player.GetComponent<PlayerMovement_Jon>().enabled = true;
                press = false;
                Interact.SetActive(true);
            }
        }
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerinRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerinRange = false;
            Interact.SetActive(false);

        }
    }
}
