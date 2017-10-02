using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWarrior : MonoBehaviour {

    GameObject enemy;
    public float speed = 100f;
    public float hitpoint = 5;
	// Use this for initialization
	void Start () {
        enemy = GameObject.FindGameObjectWithTag("Enemigo");
    }
	
	// Update is called once per frame
	void Update () {

        var distance = Vector3.Distance(enemy.transform.position, transform.position);

        if (distance < 100)
        {

            var delta = enemy.transform.position - transform.position;
            delta.Normalize();
            var moveSpeed = speed * Time.deltaTime;
            transform.position = transform.position + (delta * moveSpeed);
            transform.LookAt(enemy.transform);
        }
        

    }

    private void OnCollisionEnter(Collision _collision)
    {
        GameObject contacto = _collision.gameObject;
        if (contacto.GetComponent<iDestruible>() != null) {
            iDestruible daño = contacto.GetComponent<iDestruible>();
            daño.Destruir(hitpoint);
        }
    }
}
