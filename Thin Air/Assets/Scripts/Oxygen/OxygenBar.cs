﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour {

    Image oxygenBar;
    [SerializeField]
    private GameObject player;

    private float currentOxygen;
    private float maxOxygen;
	// Use this for initialization
	void Start () {

        oxygenBar = GetComponent<Image>();
        currentOxygen = (player.GetComponent("Oxygen") as Oxygen).CurrentOxygen;
        maxOxygen = (player.GetComponent("Oxygen") as Oxygen).MaxOxygen;
	}
	
	// Update is called once per frame
	void Update () {
        currentOxygen = (player.GetComponent("Oxygen") as Oxygen).CurrentOxygen;
        oxygenBar.fillAmount = currentOxygen / maxOxygen;
	}
}