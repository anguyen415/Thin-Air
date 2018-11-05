using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigDoorSlide : MonoBehaviour {

	public	GameObject LeftDoor;
	public GameObject RightDoor;
    public GameObject checkKeypad;
    [SerializeField]
    private bool unlocked = false;
    Animator anim;
	Vector3 origL, origR;

	// Use this for initialization
	void Start ()
	{
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (checkKeypad.GetComponent<KeyPad>().checkLock() || unlocked)
        {
            anim.SetTrigger("Unlock");
        }
   
    }

	
}
