﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Player") 
		{
			GameObject.Find ("Player").GetComponent<InputController> ().enabled = false;
		}
	}
}
