﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideOpen : MonoBehaviour {
	public	GameObject LeftDoor;
	public GameObject RightDoor;
	Vector3 origL, origR;
	public GameObject player;

	float Distance = 4;

	public bool playerClose;
	public float offsetX;
	public float offsetZ;
	float Xdistance;
	float Zdistance;


	// Use this for initialization
	void Start ()
	{
		origL = LeftDoor.transform.localPosition;
		origR = RightDoor.transform.localPosition;
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
		LeftDoor.transform.localPosition = new Vector3(origL.x + 2.3f, origL.y, origL.z);
		RightDoor.transform.localPosition = new Vector3(origR.x - 2.3f, origR.y, origR.z);
	}

	void closeDoors()
	{
		LeftDoor.transform.localPosition = new Vector3(origL.x, origL.y, origL.z);
		RightDoor.transform.localPosition = new Vector3(origR.x, origR.y, origR.z);
	}

	void checkDistance()
	{
		Xdistance = Mathf.Abs(player.transform.position.x - transform.position.x + offsetX);
		Zdistance = Mathf.Abs(player.transform.position.z - transform.position.z + offsetZ);
		if (Xdistance < Distance && Zdistance < Distance)
			playerClose = true;
		else
			playerClose = false;
	}
}
