using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grasshopper : MonoBehaviour, IEnemies
{
    public float life = 100;
    Slider lifeSlider;
    Transform mTransform;
    Vector3 initialPosition;
    Rigidbody mBody;
    GameObject player;
    Transform playerTransform;
    public string playerName = "Master";
    float moveSpeed = 5.0f;
    //float maxDist = 20.0f;
    float minDist = 2.0f;
    bool attackCooldown = true;
    float t = 0.0f;
    float cooldownTime = 3f;
    float damage = 10.0f;

    // Use this for initialization
    void Start()
    {
        mTransform = GetComponent<Transform>();
        lifeSlider = GetComponentInChildren<Slider>();
        lifeSlider.value = 100f;
        initialPosition = mTransform.position;
        mBody = GetComponent<Rigidbody>();
        playerTransform = GameObject.Find(playerName).GetComponent<Transform>();
        player = GameObject.Find(playerName);
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeSlider.value = life;

		if(life <= 0)
        {
            gameObject.SetActive(false);
            mTransform.position = initialPosition;
            mBody.velocity = new Vector3(0, 0, 0);
        }

        if(GameObject.Find(playerName).activeInHierarchy)
        {

            if (player.activeInHierarchy)
            {
                mTransform.LookAt(playerTransform);
                mTransform.position += mTransform.forward * moveSpeed * Time.deltaTime;

                if (Vector3.Distance(mTransform.position, playerTransform.position) <= minDist)
                {
                    if (attackCooldown == true)
                    {
                        attackCooldown = false;
                        t = 0f;
                        MeleeAttack();
                    }
                }
            }
        }
        if(attackCooldown == false)
        {
            t += Time.deltaTime;
        }
        if(t >= cooldownTime)
        {
            attackCooldown = true;
        }
	}

    public void Destroy(float _damage)
    {
        life -= _damage;
    }
    public void MeleeAttack()
    {
        if(player.GetComponent<IAnts>() != null)
        {
            IAnts iAnts = player.GetComponent<IAnts>();
            iAnts.Damage(damage);
        }
    }
}
