using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainRotate : MonoBehaviour
{

    Transform mTransform;
    Transform target;

	// Use this for initialization
	void Start ()
    {
        mTransform = GetComponent<Transform>();
        target = GameObject.Find("House").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        mTransform.LookAt(target);
        mTransform.Translate(Vector3.right * Time.deltaTime);
	}
}
