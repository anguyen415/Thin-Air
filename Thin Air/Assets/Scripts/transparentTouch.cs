using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparentTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collision) {
        if(collision.name == "Transparent")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        
    }

    void OnTriggerExit(Collider collision) {
        if (collision.name == "Transparent")
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        

    }
}
