using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    [SerializeField]
    private int CurrentOxygen;
    [SerializeField]
    private int MaxOxygen = 100;
    [SerializeField]
    private float tickRate = 3; //in ms --> 300 means -1 health every 3 seconds
    [SerializeField]
    private int decreasePerTick = 1;
    private float delaytime;
    // Use this for initialization
    void Start()
    {
        delaytime = Time.time + tickRate;
        CurrentOxygen = MaxOxygen;
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
            Destroy(gameObject);
        }
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
}
