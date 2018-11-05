using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bootlegCameraChange : MonoBehaviour {
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;
    [SerializeField]
    private float z;
    private Vector3 position;
    private bool changeCam;
    private float speed = 1f;
	// Use this for initialization
	void Start () {
        position = new Vector3(x, y, z);
        position = cam.transform.position - position;
        changeCam = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (changeCam)
        {
            if (cam.transform.position.y > position.y)
            {
                Debug.Log(cam.transform.position);
                Debug.Log(position.y);

                float step = speed * Time.deltaTime;
                cam.transform.position = Vector3.MoveTowards(cam.transform.position, position, step);
            }
            else
            {
                changeCam = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            changeCam = true;
        }
    }
}
