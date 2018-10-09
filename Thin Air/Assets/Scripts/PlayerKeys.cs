using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour {
    private bool[] keys;
	// Use this for initialization
	void Start () {
        keys = new bool[5];
        for(int i = 0; i < 5; i++)
        {
            keys[i] = false;
        }
}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void giveKeys(int keynumber) 
    {
        keys[keynumber] = true;
    }
    public bool Havekey(int keynumber)
    {
        return keys[keynumber];
    }
}
