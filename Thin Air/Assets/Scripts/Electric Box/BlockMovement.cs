using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour {

	GameObject spot;

	// Use this for initialization
	void Start()
	{
		spot = GameObject.Find("EMPTY");
	}

	// Update is called once per frame
	void Update() {

	}

	void OnMouseDown() // object was clicked - do something
	{
		moveBlock();
	}

	void moveBlock()
	{
		if (canMove())
		{

			/* do {
                 transform.position = Vector3.MoveTowards(transform.position, spot.transform.position, 0.25f * Time.deltaTime);
             } while (transform.position != spot.transform.position);*/

			Vector3 temp = transform.position;

			transform.position = spot.transform.position;

			spot.transform.position = temp;
		}
	}

	bool canMove()
	{
		float diff1 = (Mathf.Abs(transform.localPosition.y - spot.transform.localPosition.y));
		float diff2 = (Mathf.Abs(transform.localPosition.x - spot.transform.localPosition.x));

		if (transform.localPosition.x == spot.transform.localPosition.x)
			if (diff1 < transform.localScale.x + 0.01f)
				return true;
		if (transform.localPosition.y == spot.transform.localPosition.y)
			if (diff2 < transform.localScale.x + 0.01f)
				return true;

		return false;
	}
}
