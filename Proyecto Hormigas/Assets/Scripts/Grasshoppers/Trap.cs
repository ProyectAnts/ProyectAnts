using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisioned = collision.gameObject;

        if(collisioned.tag == "Grasshopper")
        {
            collisioned.gameObject.SetActive(false);
        }
    }
}
