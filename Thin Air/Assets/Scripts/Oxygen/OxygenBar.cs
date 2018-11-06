using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour {

    Image oxygenBar;
    [SerializeField]
    private GameObject player;
	[SerializeField]
	private Text amount;

	private float currentOxygen;
    private float maxOxygen;

    private Text currentOxygenText;
	// Use this for initialization
	void Start () {
        amount = GameObject.Find("oxygenText").GetComponent<Text>();
        oxygenBar = GetComponent<Image>();
        currentOxygen = player.GetComponent<Oxygen>().getCurrentOxygen();
        maxOxygen = (player.GetComponent("Oxygen") as Oxygen).MaxOxygen;
	}
	
	// Update is called once per frame
	void Update () {
        currentOxygen = Oxygen.CurrentOxygen;
        oxygenBar.fillAmount = currentOxygen / maxOxygen;
        amount.text = Mathf.Floor(currentOxygen/maxOxygen*100).ToString();
	}
}
