using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    [SerializeField]
    private float damage;

	private GameObject playerSound;

    // Use this for initialization
    void Start()
    {
		playerSound = GameObject.FindGameObjectWithTag("PlayerSound");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Oxygen>().HurtPlayer(damage);
			playerSound.GetComponent<AudioManager>().NextLevel = 3;
		}
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Oxygen>().HurtPlayer(damage);
			playerSound.GetComponent<AudioManager>().NextLevel = 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerSound.GetComponent<AudioManager>().NextLevel = 2;
        }
    }
}
