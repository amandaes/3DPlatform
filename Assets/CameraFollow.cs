using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Transform camTransform;

    private Camera cam;
    public float distanceZ = 10f;
    public float distanceX = 10f;
    public float distanceY = 10f;
    private float currentX = 0f;
    private float currentY = 0f;
    private float sensivityX = 4f;
    private float sensivityY = 1f;


    // Use this for initialization
    void Start () {

        camTransform = transform;
        cam = Camera.main;

	}


    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

    }


    private void LateUpdate()
    {
        Vector3 dir = new Vector3(-distanceX, -distanceY, -distanceZ);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = target.position + dir;
        camTransform.LookAt(target.position);

     }

    // Update is called once per frame
    
}
