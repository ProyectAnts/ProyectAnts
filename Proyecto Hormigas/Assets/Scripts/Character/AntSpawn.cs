using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawn : MonoBehaviour {

    public int timesPressed = 0;
    public float timePassing = 0f;
    public bool coolDown = false;
    Transform spawnPoint;
    GameObject antWorker, antArcher, antWarrior;

	// Use this for initialization
	void Start () {
        spawnPoint = GameObject.Find("Spawn Point").GetComponent<Transform>();
        antWorker = GameObject.Find("AntWorker");
        antWarrior = GameObject.Find("AntWarrior");
        antArcher = GameObject.Find("AntArcher");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnWorker()
    {
        if (coolDown == true) { timePassing += Time.deltaTime; }
        if (Input.GetButtonDown("Worker"))
        {
            coolDown = true;
            timesPressed += 1;

            if (timesPressed >= 2)
            {
                Vector3 spawn = spawnPoint.position;
                GameObject antWorkerClone = Instantiate(antWorker, spawn, Quaternion.identity);
                timesPressed = 0;
                timePassing = 0;
                coolDown = false;
            }
        }
        if (timePassing >= 1)
        {
            timePassing = 0;
            timesPressed = 0;
            coolDown = false;
        }
    }
    public void SpawnArcher()
    {
        if (coolDown == true) { timePassing += Time.deltaTime; }
        if (Input.GetButtonDown("Archer"))
        {
            coolDown = true;
            timesPressed += 1;

            if (timesPressed >= 2)
            {
                Vector3 spawn = spawnPoint.position;
                GameObject antArcherClone = Instantiate(antArcher, spawn, Quaternion.identity);
                timesPressed = 0;
                timePassing = 0;
                coolDown = false;
            }
        }
        if (timePassing >= 1)
        {
            timePassing = 0;
            timesPressed = 0;
            coolDown = false;
        }
    }
    public void SpawnWarrior()
    {
        if (coolDown == true) { timePassing += Time.deltaTime; }
        if (Input.GetButtonDown("Warrior"))
        {
            coolDown = true;
            timesPressed += 1;

            if (timesPressed >= 2)
            {
                Vector3 spawn = spawnPoint.position;
                GameObject antWarriorClone = Instantiate(antWarrior, spawn, Quaternion.identity);
                timesPressed = 0;
                timePassing = 0;
                coolDown = false;
            }
        }
        if (timePassing >= 1)
        {
            timePassing = 0;
            timesPressed = 0;
            coolDown = false;
        }
    }
}
