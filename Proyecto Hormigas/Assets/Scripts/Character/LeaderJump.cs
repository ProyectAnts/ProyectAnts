using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderJump : MonoBehaviour {

    Transform mTransform;
    Rigidbody mBody;
    private float jumpForce = 200;
    private bool jumpGround = false;

	// Use this for initialization
	void Start () {
        mBody = GetComponent<Rigidbody>();
        mTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
    
	}
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpGround == true)
        {
            Vector3 directionJump = mTransform.up;
            float sense = 1;

            mBody.AddForce(directionJump * sense * jumpForce);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        jumpGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        jumpGround = false;
    }
}
