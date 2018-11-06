using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasEnemyAnimation : MonoBehaviour {

	private Quaternion Target;
	public float spinDegree = 5f;
	public float moveDegree = 3f;

	// Use this for initialization
	void Start ()
	{
//		Target = transform.rotation;
	//	Target.y = spinDegree;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(0, spinDegree * Time.deltaTime, moveDegree * Time.deltaTime); //rotates 'spinDegree' degrees per second around y axis
	}
}
