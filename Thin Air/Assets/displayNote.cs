using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayNote : MonoBehaviour
{
	public GameObject UI;
	bool onNote;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(onNote == true)
			if (Input.GetButtonDown("Temp Cancel"))
			{
				onNote = false;
				UI.SetActive(false);
			}

	}

	void OnMouseDown() // object was clicked - do something
	{
		UI.SetActive(true);
		onNote = true;
	}

}