using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigDoorSlide : MonoBehaviour {

	public	GameObject LeftDoor;
	public GameObject RightDoor;
    public GameObject checkKeypad;
    private bool unlocked = false;
	Vector3 origL, origR;

	// Use this for initialization
	void Start ()
	{

	}

    // Update is called once per frame
    void Update()
    {
        if (checkKeypad.GetComponent<KeyPad>().checkLock())
        {
            openDoors();
        }
   
    }

	void openDoors()
	{
		LeftDoor.transform.localPosition = new Vector3(origL.x - .016f, origL.y, origL.z);
		RightDoor.transform.localPosition = new Vector3(origR.x +.016f, origR.y, origR.z);
	}

	
}
