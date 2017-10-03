using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    string enemyTag = "Grasshopper";
    Transform mTransform;
    bool inRange = false;
    float coolDown = 0;
    float minRange = 20, maxRange = 300, minMagnitude = 350, maxMagnitude = 725;

    AudioSource shotSound;

    GameObject enemy;
    Transform enemyTransform;

    void Start ()
    {
        mTransform = GameObject.Find("Bow").GetComponent<Transform>();
        shotSound = GetComponent<AudioSource>();
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        enemy = FindClosestEnemy();
        enemyTransform = enemy.transform;
    }
	
	void Update ()
    {
        if (enemy.GetComponent<Grasshopper>().life <= 0 && enemy != null)
        {
            enemy = FindClosestEnemy();
            enemyTransform = enemy.transform;
        }
        ShootCondition(enemyTransform);
    }

    public void ShootCondition(Transform enemyTransform)
    {
        Vector3 heading = enemyTransform.position - mTransform.position;// Gets a vector that points from the player's position to the target's.

        if (heading.sqrMagnitude < maxRange && heading.sqrMagnitude > minRange)
        {
            // Target is within range.
            BowShoot(enemyTransform);
            inRange = true;
            coolDown += Time.deltaTime;
        }
        else
        {
            inRange = false;
        }
    }

    public void BowShoot(Transform enemyTransform)
    {
        GameObject arrow = ArrowPool.SharedInstance.GetArrow();

        if (arrow != null)
        {
            Vector3 heading = enemyTransform.position - mTransform.position;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance; // This is now the normalized direction.
            Vector3 par = new Vector3(0, 0.4f, 0);

            float m = (maxMagnitude - minMagnitude) / (maxRange - minRange);
            float b = 4525 / 14;
            float r = Random.Range(minRange, maxRange);

            float magnitude = m * r + b;

            if (inRange == true && coolDown >= 2 && enemy.activeInHierarchy == true)
            {
                shotSound.Play();
                arrow.transform.position = mTransform.position;
                arrow.transform.rotation = Quaternion.identity;
                arrow.SetActive(true);

                Rigidbody rArrow = arrow.GetComponent<Rigidbody>();

                rArrow.AddForce(magnitude * (direction + par));

                Arrow mArrow = arrow.GetComponent<Arrow>();
                mArrow.shot = true;
                coolDown = 0;
            }
        }
    }
    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = mTransform.position;
        foreach(GameObject enemy in enemies)
        {
            Vector3 difference = enemy.transform.position - mTransform.position;
            float currentDistance = difference.sqrMagnitude;
            if(currentDistance < distance)
            {
                closest = enemy;
                distance = currentDistance;
            }
        }
        return closest;
    }
}
