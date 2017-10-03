using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(string _levelName) {
        SceneManager.LoadScene(_levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
