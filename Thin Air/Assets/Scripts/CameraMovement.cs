using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private Transform target_player;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private bool useOffsetValues;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private Transform pivot;
    [SerializeField]
    private float minViewAngle;
    [SerializeField]
    private float maxViewAngle;
    [SerializeField]
    private bool invertY;

    // Use this for initialization
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target_player.position - transform.position;
        }

        pivot.transform.position = target_player.transform.position;
        // pivot.transform.parent = target_player.transform;
        Cursor.lockState = CursorLockMode.Locked;
        pivot.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        pivot.transform.position = target_player.transform.position;
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //pivot.Rotate(vertical, 0, 0);
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < (360f + minViewAngle))
        {
            pivot.rotation = Quaternion.Euler((360f + minViewAngle), 0, 0);
        }
        float desiredYAngle = pivot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);
        transform.position = target_player.position - (rotation * offset);
        if (transform.position.y < target_player.position.y)
        {
            transform.position = new Vector3(transform.position.x, target_player.position.y, transform.position.z);
        }
        transform.LookAt(target_player);

    }
}
