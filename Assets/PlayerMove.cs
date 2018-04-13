using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 5f;
    public bool touchGround;
    public float jumpSpeed = 10f;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        touchGround = true;
	}
	
	// Update is called once per frame
	void Update () {

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if (touchGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(0f, jumpSpeed, 0f);
                touchGround = false;
            }
        }

	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            touchGround = true;
        }
    }
}
