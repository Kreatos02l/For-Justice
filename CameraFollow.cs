﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float CameraMoveSpeed = 120.0f;
	public GameObject CameraFollowObj;
	Vector3 FollowPOS;
	public float clampAngle = 30.0f;
	public float inputSensitivity = 150.0f;
	public GameObject CameraObj;
	public GameObject PlayerObj;
	public float camDistanceXToPlayer;
	public float camDistanceYToPlayer;
	public float camDistanceZToPlayer;
	public float mouseX;
	public float mouseY;
    public float smoothX;
	public float smoothY;
	private float rotY = 0.0f;
	private float rotX = 0.0f;


    // Use this for initialization
    void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	//void Update () {
		// Setup the rotation of the sticks here
   //     mouseX = Input.GetAxis("Mouse X");
   //     mouseY = Input.GetAxis("Mouse Y");
   
   //     rotY += mouseX * inputSensitivity * Time.deltaTime;
	//	rotX += mouseY * inputSensitivity * Time.deltaTime;

	//	rotX = Mathf.Clamp (rotX, -clampAngle, (clampAngle + 20));

	//	Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
	//	transform.rotation = localRotation;

    //}


	void LateUpdate(){
		CameraUpdater();
	}

	void CameraUpdater(){
		//Set the target object to follow
		Transform target = CameraFollowObj.transform;

        //Move toward the game object that is the target
		float step = CameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
}