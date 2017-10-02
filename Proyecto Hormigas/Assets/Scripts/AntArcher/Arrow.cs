using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    Rigidbody mBody;
    Vector3 initialPos;
    public bool shot = false;
    public float duration = 6;
    float t = 0;
    public float damage = 20;
    void Start ()
    {
        mBody = GetComponent<Rigidbody>();
        initialPos = new Vector3();
        initialPos = gameObject.GetComponent<Transform>().position;
    }
	
	void Update ()
    {
        if (shot == true)
        {
            t += Time.deltaTime;
            if (t >= duration)
            {
                gameObject.SetActive(false);
                gameObject.GetComponent<Transform>().position = initialPos;
                t = 0;
                shot = false;
            }
        }	
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisioned = collision.gameObject;

        if (collisioned.GetComponent<IEnemies>() != null) {
            IEnemies iEnemies = collisioned.GetComponent<IEnemies>();
            iEnemies.Destroy(damage);
        }
    }
}
