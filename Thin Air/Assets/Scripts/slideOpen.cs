using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideOpen : MonoBehaviour {
	public	GameObject LeftDoor;
	public GameObject RightDoor;
    public bool doorUnlocked = false;
    public AudioSource source;
    public AudioClip swish;
	Vector3 origL, origR;
	//public GameObject player;
	GameObject player;

	float Distance = 4;

	public bool playerClose;
	public float offsetX;
	public float offsetZ;
	float Xdistance;
	float Zdistance;
    private bool played;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		origL = LeftDoor.transform.localPosition;
		origR = RightDoor.transform.localPosition;
        played = false;
	}

    // Update is called once per frame
    void Update()
    {
        checkDistance();
        if (doorUnlocked) {
            if (playerClose)
                openDoors();
            else
                closeDoors();
        }
	}

	void openDoors()
	{
        if (!played)
        {
            //source.PlayOneShot(swish, 1f);
            played = true;
        }
        LeftDoor.transform.localPosition = new Vector3(origL.x + 2.3f, origL.y, origL.z);
		RightDoor.transform.localPosition = new Vector3(origR.x - 2.3f, origR.y, origR.z);
        
    }

	void closeDoors()
	{
		LeftDoor.transform.localPosition = new Vector3(origL.x, origL.y, origL.z);
		RightDoor.transform.localPosition = new Vector3(origR.x, origR.y, origR.z);
        played = false;
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

    public void unlockDoor()
    {
        doorUnlocked = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerClose = true;
        }
    }
}
