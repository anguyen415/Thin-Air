using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour {

    [SerializeField]
    bool counterclockwise; // rotation left or right?
    [SerializeField]
    private int speed;

    private void Start()
    {
        if (counterclockwise)
            speed = -speed;


    }

    private void FixedUpdate()
    {
        
        transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    
}
