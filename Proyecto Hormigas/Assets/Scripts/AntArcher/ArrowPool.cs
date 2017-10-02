using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour {

    public static ArrowPool SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    public int arrowNumber = 5;
    List<GameObject> arrowPool; 
    GameObject arrow; 

    void Start () {
        arrow = GameObject.Find("Arrow");
        arrowPool = new List<GameObject>();
        for (int i = 0; i < arrowNumber; i++)
        {
            GameObject arowClone = Instantiate(arrow);
            arowClone.SetActive(false);
            arrowPool.Add(arowClone);
        }
    }
	
	void Update () {
		
	}

    public GameObject GetArrow()
    {
        for (int i = 0; i < arrowPool.Count; i++)
        {
            if (!arrowPool[i].activeInHierarchy)
            {
                return arrowPool[i];
            }
        }
        return null;
    }
}
