using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMovement : MonoBehaviour
{
	Vector3 p0 = new Vector3(-17.9f, 0.0f, -7.9f);
	Vector3 a0 = new Vector3(0.0f, -150.0f, 0.0f);
	Vector3 p1 = new Vector3(0f, 0f, 0f);
	Vector3 a1 = new Vector3(0f, 0f, 0f);

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnMouseDown() // object was clicked - do something
	{
		openClose();
	}

	void openClose()
	{

		if (transform.parent.localPosition.x != 0) // is closed
		{
			transform.parent.localPosition = p1;
			transform.parent.localEulerAngles = a1;
		//	open = true;
		}
		else // is open
		{
			transform.parent.localPosition = p0;
			transform.parent.localEulerAngles = a0;
		//	open = false;
		}

	}

}