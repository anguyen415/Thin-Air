using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxyPackSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject oxyPackPrefab;
    [SerializeField]
    private float spawnDelay;//in seconds
    [SerializeField]
    private bool spawned = false;
    
    private float delayTime;
   // [SerializeField]
    //private float tickRate = 5f;
    // Use this for initialization
    void Start() {
        //delayTime = Time.time + tickRate;
        spawned = true;
        MakeTank();

    }

    public void MakeTank() {

        Instantiate(oxyPackPrefab, this.transform.position, Quaternion.identity);
    }

	// Update is called once per frame
	void FixedUpdate () {

        if (!spawned)// && (Time.time > delayTime))
        {
            //spawned = true;
           // MakeTank();
            StartCoroutine(WaitForSpawn());
        }



    }

    public IEnumerator WaitForSpawn() {

        spawned = true;
        yield return new WaitForSeconds(spawnDelay);
        MakeTank();

    }
    public void setSpawn(bool state) {
        spawned = state;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setSpawn(false);
        }
    }
}
