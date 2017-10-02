using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grasshopper : MonoBehaviour
{
    public float life = 100;
    Slider lifeSlider;
    Transform mTransform;
    Vector3 initialPosition;
    Rigidbody mBody;

    // Use this for initialization
    void Start()
    {
        mTransform = GetComponent<Transform>();
        lifeSlider = GetComponentInChildren<Slider>();
        lifeSlider.value = 100f;
        initialPosition = mTransform.position;
        mBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        mTransform.position += new Vector3(0.4f, 0, 0);
        lifeSlider.value = life;

		if(life <= 0)
        {
            gameObject.SetActive(false);
            mTransform.position = initialPosition;
            mBody.velocity = new Vector3(0, 0, 0);
        }
	}
}
