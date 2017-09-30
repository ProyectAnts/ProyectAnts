using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCreateObjectEmpty : MonoBehaviour {

    public Transform theLocation;
    MouseSearch mMouse;

	// Use this for initialization
	void Start () {
        theLocation = GameObject.Find("Reference Walking Point").GetComponent<Transform>();
        mMouse = GetComponent<MouseSearch>();
        mMouse.CreateEmptyObject += EmptyObjectCreation;
    }
	
	// Update is called once per frame
	void Update () {
    }
    public void EmptyObjectCreation()
    {
        RaycastHit mousePosition;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mousePosition, 100))
        {
            theLocation.position = mousePosition.point;
        }
    }
}
