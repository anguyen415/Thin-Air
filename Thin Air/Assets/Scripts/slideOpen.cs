using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideOpen : MonoBehaviour {
	GameObject Left;
	GameObject Right;
	Vector3 originL;
	Vector3 originR;
	public GameObject player;

	public float Distance;

	public bool playerClose;
	float Xdistance;
	float Zdistance;


	// Use this for initialization
	void Start ()
	{
		Left = GameObject.Find("Door_1");
		Right = GameObject.Find("Door_2");
		originL = Left.transform.localPosition;
		originR = Right.transform.localPosition;
	}

	// Update is called once per frame
	void Update ()
	{
		checkDistance();

		if (playerClose)
			openDoors();
		else
			closeDoors();
	}

	void openDoors()
	{
		float newX = originL.x + 2.3f;
		Left.transform.localPosition.Set(newX, Left.transform.localPosition.y, Left.transform.localPosition.z);
	}

	void closeDoors()
	{
		float newX = originL.x;
		Left.transform.localPosition.Set(newX, Left.transform.localPosition.y, Left.transform.localPosition.z);
	}

	void checkDistance()
	{
		Xdistance = Mathf.Abs(player.transform.position.x - transform.position.x + 1.5f);
		Zdistance = Mathf.Abs(player.transform.position.z - transform.position.z);
		if (Xdistance < Distance && Zdistance < Distance)
			playerClose = true;
		else
			playerClose = false;
	}
}
