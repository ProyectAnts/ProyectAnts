using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSearch : MonoBehaviour
{

    public delegate void MouseFoundAnAnt();
    public event MouseFoundAnAnt WorkerFound;
    public event MouseFoundAnAnt ArcherFound;
    public event MouseFoundAnAnt WarriorFound;
    public event MouseFoundAnAnt WorkerLost;
    public event MouseFoundAnAnt ArcherLost;
    public event MouseFoundAnAnt WarriorLost;
    public event MouseFoundAnAnt AntDeselected;
    public event MouseFoundAnAnt CreateEmptyObject;
    public bool workerS = false, archerS = false, warriorS = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FindWorker();
        FindArcher();
        FindWarrior();
        DeselectEverything();
        CreateObjectEvent();
    }
    public void FindWorker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "AntWorker")
            {
                workerS = true;
                archerS = false;
                warriorS = false;
                ChooseAnt();
                CreateObjectEvent();
            }
        }
    }
    public void FindArcher()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "AntArcher")
            {
                workerS = false;
                archerS = true;
                warriorS = false;
                ChooseAnt();
                CreateObjectEvent();
            }
        }
    }
    public void FindWarrior()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "AntWarrior")
            {
                workerS = false;
                archerS = false;
                warriorS = true;
                ChooseAnt();
                CreateObjectEvent();
            }
        }
    }
    public void DeselectEverything()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            AntDeselected();
        }
    }
    public void ChooseAnt()
    {
        if (workerS == true)
        {
            WorkerFound();
            ArcherLost();
            WarriorLost();
        }
        if (archerS == true)
        {
            WorkerLost();
            ArcherFound();
            WarriorLost();
        }
        if (warriorS == true)
        {
            WorkerLost();
            ArcherLost();
            WarriorFound();
        }
    }
    public void CreateObjectEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateEmptyObject();
        }
    }
}
