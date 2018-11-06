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
    private int decreasePerTick = 1;
    private float delaytime;
    // Use this for initialization
    private bool damaged;
    [SerializeField]
    private Image damageImage;
    [SerializeField]
    private float damageFlashSpeed;
    [SerializeField]
    private Color damageFlashColor;


    void Start()
    {
        damaged = false;
        delaytime = Time.time + tickRate;
        oxygenBar = (GameObject.Find("oxygenBar").GetComponent<Image>());
		CurrentOxygen = MaxOxygen;
        SetOxygenText();
    }
    void Update()
    {
        if (CurrentOxygen / MaxOxygen <= 0.20) {
            DamageFlash();
        }
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
            if (Input.GetButton("Sprint")) {

                HurtPlayer(decreasePerTick * 2f);
            }
            else
            {
                HurtPlayer(decreasePerTick);

            }
            //CurrentOxygen = CurrentOxygen - decreasePerTick;  
            delaytime = Time.time + tickRate;
        }
        if (CurrentOxygen <= 0)
        {
            //Destroy(gameObject); //Death animation?
        }
        SetOxygenText();
        oxygenBar.fillAmount = CurrentOxygen / MaxOxygen;
    }
    public void HurtPlayer(float damage)
    {
        //CurrentOxygen -= damage;
        if (CurrentOxygen - damage < 0)
        {
            damaged = true;
            CurrentOxygen = 0;
        }
        else
        {
            damaged = true;
            CurrentOxygen -= damage;
        }
    }
    public void RestoreOxygen(float oxyamount)
    {
        CurrentOxygen += oxyamount;
        if (CurrentOxygen > MaxOxygen)
        {
            CurrentOxygen = MaxOxygen;
        }
    }


    public void SetOxygenText()
    {
        oxygenText.text = Mathf.Floor(CurrentOxygen/MaxOxygen*100).ToString();
    }

    public void DamageFlash()
    {
        if (damaged)
        {
            damageImage.color = damageFlashColor;
            

        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, damageFlashSpeed * Time.deltaTime);
            
        }
        damaged = false;
    }
    

    public float getCurrentOxygen() {
        return CurrentOxygen;
    }
}
