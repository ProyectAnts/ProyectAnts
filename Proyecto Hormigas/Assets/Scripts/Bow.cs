using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    Transform mBow;
    GameObject arrow;

    Transform mEnemy;
    bool inRange = false;
    float coolDown = 0;  

    void Start ()
    {
        mBow = GameObject.Find("Reference").GetComponent<Transform>();
        arrow = GameObject.Find("Arrow");

        mEnemy = GameObject.Find("Enemy").GetComponent<Transform>();
	}
	
	void Update ()
    {
        ShootCondition();
	}

    public void ShootCondition()
    {
        Vector3 heading = mEnemy.position - mBow.position;// Gets a vector that points from the player's position to the target's.

        if (heading.sqrMagnitude < 300)
        {
            // Target is within range.
            BowShoot();
            inRange = true;
            coolDown += Time.deltaTime;
        }
        else
        {
            inRange = false;
        }
    }

    public void BowShoot()
    {
        float magnitude = 500;
        Vector3 posBow = mBow.position;

        Vector3 heading = mEnemy.position - mBow.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance; // This is now the normalized direction.
        Vector3 par = new Vector3(0, 0.4f, 0);

        if (inRange == true && coolDown >=2 )
        {
            GameObject arrowClon = Instantiate(arrow, posBow, Quaternion.identity);
            Rigidbody rArrow = arrowClon.GetComponent<Rigidbody>();

            rArrow.AddForce(magnitude * (direction+ par));
            Destroy(arrowClon, 10);
            coolDown = 0;
        }
    }
}
