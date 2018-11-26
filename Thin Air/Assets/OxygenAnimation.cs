using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenAnimation : MonoBehaviour {
	public float spinDegree;
	public float tiltAngle;

	// Use this for initialization
	void Start ()
	{
		this.transform.Rotate(tiltAngle, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Rotate(0, spinDegree * Time.deltaTime, 0);	
	}
}
