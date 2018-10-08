using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayInteract : MonoBehaviour {
	Collider col;

	// Use this for initialization
	void Start ()
	{
		col = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter(Collider col)
	{
		GameObject.FindGameObjectWithTag("interUI").SetActive(true);
	}
	void OnTriggerExit(Collider col)
	{
		GameObject.FindGameObjectWithTag("interUI").SetActive(false);
	}
}
