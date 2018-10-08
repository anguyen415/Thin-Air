using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    [SerializeField]
    private float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*speed, 1), transform.position.z);

    }
}
