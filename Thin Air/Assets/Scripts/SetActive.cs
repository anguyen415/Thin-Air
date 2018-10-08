using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour {
    private bool PlayerinRange = false;
    [SerializeField]
    GameObject interactableObject;
    [SerializeField]
    GameObject player;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update() {
        if(PlayerinRange)
            {
            if (Input.GetButtonDown("Interact")){
                interactableObject.SetActive(true);
                player.GetComponent<PlayerMovement_anh>().enabled = false;
            }
            else if (Input.GetButtonDown("Cancel")){
                interactableObject.SetActive(false);
                player = GameObject.FindWithTag("Player");
                player.GetComponent<PlayerMovement_anh>().enabled = true;
            }
        }
	}
    public void Press()
    {
        PlayerinRange = true;
    }
    public void Left()
    {
        PlayerinRange = false;
    }
}
