using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPack : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float HealAmount = 5f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Oxygen>().RestoreOxygen(HealAmount);
            GameObject.FindWithTag("Spawner").GetComponent<OxyPackSpawner>().setSpawn(false);
            Destroy(gameObject);
        }
    }
}
