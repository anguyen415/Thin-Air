using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour {
    private bool doctorkey;
    private bool electricroomkey;
    private bool maintenanceroomkey;
	// Use this for initialization
	void Start () {
        doctorkey = false;
        electricroomkey = false;
        maintenanceroomkey = false;
}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void giveKeys(int keynumber) 
    {
        if(keynumber == 1)
        {
            doctorkey = true;
        }
        else if (keynumber == 2)
        {
            doctorkey = true;
            maintenanceroomkey = true;
        }
    }
}
