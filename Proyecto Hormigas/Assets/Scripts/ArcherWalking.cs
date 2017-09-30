﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherWalking : MonoBehaviour {

    /// <summary>
    /// Variables of the worker
    /// </summary>
    Transform mTransform, referencePoint, food;
    Rigidbody mBody; //momentaneo
    MouseSearch mMouse;
    MouseCreateObjectEmpty mEmpty;
    private float speed = 3, rotationS = 20;
    public bool selected = false;


    void Start()
    {
        mTransform = GetComponent<Transform>();
        mBody = GetComponent<Rigidbody>();
        mEmpty = GameObject.Find("Master").GetComponent<MouseCreateObjectEmpty>();
        mMouse = GameObject.Find("Master").GetComponent<MouseSearch>();
        mMouse.ArcherFound += SelectArcher;
        mMouse.ArcherLost += Deselect;
        mMouse.AntDeselected += Deselect;
    }

    void Update()
    {
        WalkingControl();
    }
    public void WalkingControl()
    {
        if (mEmpty.theLocation != null && selected == true)
        {
            referencePoint = mEmpty.theLocation.GetComponent<Transform>();
            mTransform.rotation = Quaternion.Slerp(mTransform.rotation, Quaternion.LookRotation(referencePoint.position - mTransform.position), rotationS * Time.deltaTime);
            mTransform.position += mTransform.forward * Time.deltaTime * speed;
        }
    }
    public void SelectArcher()
    {
        selected = true;
        float sense = 1;
        Vector3 dir = mTransform.up;
        mBody.AddForce(dir * sense * 100);
    }
    public void Deselect()
    {
        selected = false;
    }
}