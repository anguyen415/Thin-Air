using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public Text oxygenText;
    public Image oxygenBar;
    public static float CurrentOxygen = 100f;
    public float MaxOxygen = 100f;
    [SerializeField]
    private float tickRate = 3; //in ms --> 300 means -1 health every 3 seconds
    [SerializeField]
    private float decreasePerTick = 1;
    private float delaytime;
    // Use this for initialization
   
    void Start()
    {
        delaytime = Time.time + tickRate;
        oxygenBar = (GameObject.Find("oxygenBar").GetComponent<Image>());
        CurrentOxygen = MaxOxygen;
        SetOxygenText();
    }
    void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentOxygen < 0)
        {
            CurrentOxygen = 0;
        }
        if (CurrentOxygen > MaxOxygen)
        {
            CurrentOxygen = MaxOxygen;
        }
        if (Time.time > delaytime)
        {
            CurrentOxygen = CurrentOxygen - decreasePerTick;
            delaytime = Time.time + tickRate;
        }
        if (CurrentOxygen <= 0)
        {
            //Destroy(gameObject); //Death animation?
        }
        SetOxygenText();
        oxygenBar.fillAmount = CurrentOxygen / MaxOxygen;
    }
    public void HurtPlayer(int damage)
    {
        CurrentOxygen -= damage;
        if (CurrentOxygen < 0)
        {
            CurrentOxygen = 0;
        }
    }
    public void RestoreOxygen(int oxyamount)
    {
        CurrentOxygen += oxyamount;
        if (CurrentOxygen > MaxOxygen)
        {
            CurrentOxygen = MaxOxygen;
        }
    }


    public void SetOxygenText()
    {
        oxygenText.text = "Oxygen Level: " + (CurrentOxygen/MaxOxygen*100).ToString() + "%";
    }
}
