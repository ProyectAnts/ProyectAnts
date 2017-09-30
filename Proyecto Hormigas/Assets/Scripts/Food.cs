using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IExtractResources {

    
    public float foodAvailable = 1000;
    Rigidbody mCuerpo;

	// Use this for initialization
	void Start () {
        mCuerpo = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        mCuerpo.WakeUp();
        if (foodAvailable <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Extractor(float pFood)
    {
        foodAvailable -= pFood*Time.deltaTime;
    }
}
