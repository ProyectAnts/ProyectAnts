using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHarvest : MonoBehaviour {


    public float extractionRatio = 100;
    Rigidbody mCuerpo;
    

	// Use this for initialization
	void Start () {
     
        mCuerpo = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        mCuerpo.WakeUp();
    }

    private void OnCollisionStay(Collision pCollision)
    {
        GameObject arrived = pCollision.gameObject;
        if (arrived.GetComponent<IExtractResources>() != null)
        {
            IExtractResources resourcesInterface = arrived.GetComponent<IExtractResources>();
            resourcesInterface.Extractor(extractionRatio);
        }
    }
}
