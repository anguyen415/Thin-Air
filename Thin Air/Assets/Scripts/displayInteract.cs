using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayInteract : MonoBehaviour {
	Collider player;
	public GameObject UI;
    private bool display;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find("Player").GetComponent<Collider>();
		UI.SetActive(false);
        display = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

    void OnTriggerEnter(Collider other)
    {
        if (display)
        {
            if (other == player)
                UI.SetActive(true);
        }
    }

	void OnTriggerStay(Collider other)
	{
        if (display)
        {
            if (other == player)
                UI.SetActive(true);
        }
    }

	void OnTriggerExit(Collider other)
	{
		if (other == player)
			UI.SetActive(false);
	}

    public void removeDisplay()
    {
        display = false;
    }
}
