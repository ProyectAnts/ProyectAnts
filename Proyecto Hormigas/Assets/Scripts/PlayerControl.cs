using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    LeaderWalking mWalking;
    LeaderJump mJump;
    AntSpawn mAnts;
    

	// Use this for initialization
	void Start () {
        mWalking = GetComponent<LeaderWalking>();
        mJump = GetComponent<LeaderJump>();
        mAnts = GetComponent<AntSpawn>();
        
	}
	
	// Update is called once per frame
	void Update () {
        mWalking.Walk();
        mWalking.Rotation();
        mJump.Jump();
        mAnts.SpawnWorker();
        mAnts.SpawnArcher();
        mAnts.SpawnWarrior();
    }
}
