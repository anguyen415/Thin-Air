using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private Transform target_player;
    [SerializeField]
    private float height = 10f;
    [SerializeField]
    private float distance = 20f;
    [SerializeField]
    private float angle = 45f;
    private Vector3 refVelocity;
	// Use this for initialization
	void Start () {
        HandleCamera();
 
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleCamera();

    }

    protected void HandleCamera()
    {
        if (!target_player)
        {
            return;
        }
        Vector3 worldPosition = (Vector3.forward * distance) + (Vector3.up * height);
        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;
        Vector3 flatPosition = (target_player.position);
        flatPosition.y = 0f;
        Vector3 finalPosition = flatPosition + rotatedVector;
        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, .5f);
        transform.LookAt(flatPosition);
    }
}
