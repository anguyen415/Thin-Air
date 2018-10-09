using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayKeyInteract : MonoBehaviour {
    Collider player;
    [SerializeField]
    private GameObject UI;
   

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Collider>();
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == player)
            UI.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if (other == player)
            UI.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other == player)
            UI.SetActive(false);
    }
}
