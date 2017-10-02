using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainRotate : MonoBehaviour
{

    Transform mTransform;

	// Use this for initialization
	void Start ()
    {
        mTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        mTransform.Rotate(new Vector3(0, 0.5f, 0));
	}
}
