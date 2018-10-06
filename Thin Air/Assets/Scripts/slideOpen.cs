using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideOpen : MonoBehaviour {
	GameObject Left = GameObject.Find("Door_1");
	GameObject Right = GameObject.Find("Door_2");
	float originL = GameObject.Find("Door_1").transform.localPosition.x;
	float originR = GameObject.Find("Door_2").transform.localPosition.x;
	public GameObject player;

	public float Distance;

	public bool playerClose;
	float XdistanceSqr;
	float ZdistanceSqr;


	// Use this for initialization
	void Start (){
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
		float newX = originL + 2.3f;
		Left.transform.localPosition.Set(newX, Left.transform.localPosition.y, Left.transform.localPosition.z);
	}

	void closeDoors()
	{
		float newX = originL;
		Left.transform.localPosition.Set(newX, Left.transform.localPosition.y, Left.transform.localPosition.z);
	}

	void checkDistance()
	{
		XdistanceSqr = Mathf.Pow(player.transform.position.x - transform.position.x,2);
		ZdistanceSqr = Mathf.Pow(player.transform.position.z - transform.position.z,2);
		if (XdistanceSqr < Distance && ZdistanceSqr < Distance)
			playerClose = true;
		else
			playerClose = false;
	}
}
