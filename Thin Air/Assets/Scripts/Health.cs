using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int CurrentHealth = 100;
    [SerializeField]
    private int MaxHealth = 100;
    [SerializeField]
    private float tickRate = 3; //in ms --> 300 means -1 health every 3 seconds
    [SerializeField]
    private int decreasePerTick = 1;
    private float delaytime;
    // Use this for initialization
    void Start()
    {
        delaytime = Time.time + tickRate;
    }
    void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        if (Time.time > delaytime)
        {
            CurrentHealth = CurrentHealth - decreasePerTick;
            delaytime = Time.time + tickRate;
        }
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
