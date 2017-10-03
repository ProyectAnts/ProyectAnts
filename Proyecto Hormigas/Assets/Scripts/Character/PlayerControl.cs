using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour, IAnts {

    LeaderWalking mWalking;
    LeaderJump mJump;
    AntSpawn mAnts;
    Slider lifeSlider;
     public float life = 100.0f;

	// Use this for initialization
	void Start ()
    {
        mWalking = GetComponent<LeaderWalking>();
        mJump = GetComponent<LeaderJump>();
        mAnts = GetComponent<AntSpawn>();
        lifeSlider = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeSlider.value = life;
        mWalking.Walk();
        mWalking.Rotation();
        mJump.Jump();
        mAnts.SpawnWorker();
        mAnts.SpawnArcher();
        mAnts.SpawnWarrior();
        
        if(life <= 0)
        {
            gameObject.SetActive(false);
        }
        
    }

    public void Damage(float _damage)
    {
        life -= _damage;
    }
}
