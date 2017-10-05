using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderWalking : MonoBehaviour {

    Transform mTransform;
    private float walkingMagnitude = 5;
    private float rotationMagnitude = 50;

	// Use this for initialization
	void Start () {
        mTransform = GetComponent<Transform>(); 
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    
    public void Walk()
    {
        /// This part controls movement through out forward and backward transformation
        
        Vector3 walkingDirectionZ = mTransform.forward; // Direction is assigned
        float senseZ = Input.GetAxis("Vertical"); // Sense is assigned through a keyboard input

        Vector3 velocityZ = walkingMagnitude * walkingDirectionZ * senseZ; // Velocity magnitude is registered

        Vector3 velocityTimeZ = velocityZ * Time.deltaTime; // Velocity is evaluated through out time

        mTransform.position += velocityTimeZ; // Translation is applied to the propertie transform


        /// This part controls movement through out right and left transformation

        Vector3 walkingDirectionX = mTransform.right; // Direction is assigned
        float senseX = Input.GetAxis("Horizontal"); // Sense is assigned through a keyboard input

        Vector3 velocityX = walkingMagnitude * walkingDirectionX * senseX; // Velocity magnitude is registered

        Vector3 velocityTimeX = velocityX * Time.deltaTime; // Velocity is evaluated through out time

        mTransform.position += velocityTimeX; // Translation is applied to the propertie transform

    }
    public void Rotation()
    {
        
        /// Rotacion en y
        Vector3 rotationDirectionY = mTransform.up; // Direction assigned up using character as the reference point
        float rotationSenseY = Input.GetAxis("Mouse X"); // Rotation sense assigned using the mouse as an input

        Vector3 rotationVelocityY = rotationDirectionY * rotationSenseY * rotationMagnitude; // Rotation velocity

        Vector3 rotationVelocityTimeY = rotationVelocityY * Time.deltaTime; // Rotation is evaluated through time

        mTransform.eulerAngles += rotationVelocityTimeY; // Rotation is applied to the propertie transform
        
        /*
        /// Rotacion en x
        Vector3 rotationDirectionX = mTransform.right; // Direction assigned up using character as the reference point
        float rotationSenseX = Input.GetAxis("Mouse Y"); // Rotation sense assigned using the mouse as an input

        Vector3 rotationVelocityX = rotationDirectionX * rotationSenseX * rotationMagnitude; // Rotation velocity

        Vector3 rotationVelocityTimeX = rotationVelocityX * Time.deltaTime; // Rotation is evaluated through time

        mTransform.eulerAngles += rotationVelocityTimeX; // Rotation is applied to the propertie transform
        */
    }
}
