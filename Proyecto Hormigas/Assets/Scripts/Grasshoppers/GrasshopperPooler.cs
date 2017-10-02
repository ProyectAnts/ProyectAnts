using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrasshopperPooler : MonoBehaviour
{
    public static GrasshopperPooler SharedInstance;//Several scripts will need to access the object pool 
                                                   //during gameplay, and public static instance allows 
                                                   //other scripts to access it without getting a 
                                                   //Component from a GameObject.

    private void Awake()
    {
        SharedInstance = this;
    }

    public int ghNumber = 5;//Number of grasshoppers active in the scene
    List<GameObject> ghPool; //Grasshoppers Pool
    GameObject grasshopper;

    // Use this for initialization
    void Start ()
    {
        grasshopper = GameObject.Find("Grasshopper");
        ghPool = new List<GameObject>();//Starting the grasshopper list
        for (int i = 0; i < ghNumber; i++)//Filling the grasshopper pool
        {
            GameObject ghClone = Instantiate(grasshopper);//Cloning it the times we specified
            ghClone.SetActive(false);//Seting it inactive
            ghPool.Add(ghClone);//Adding it to the list
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public GameObject GetGrasshopper()//Returns a grasshopper in the list to spawn it
    {
        for (int i = 0; i < ghPool.Count; i++)//Loop to iterate throught the grasshopper list
        {
            if (!ghPool[i].activeInHierarchy)//Check if the item is NOT currently active in the scene
            {
                return ghPool[i];//If it is, the loop moves to the next position and returns the object
            }
        }
        return null;//If there is not inactive objects, exit the method and returns nothing
    }
}
