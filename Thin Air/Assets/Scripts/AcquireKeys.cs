using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireKeys : MonoBehaviour {
    [SerializeField]
    GameObject player;
    [SerializeField]
    int key;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerKeys>().giveKeys(key);
            Destroy(gameObject);
        }
    }
}
