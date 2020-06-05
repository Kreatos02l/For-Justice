using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FootStepSound : MonoBehaviour {


	public AudioSource mySource;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) ||Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.S)){
			
			mySource.Play ();

		} 
		else 
			if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.A) ||Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
		{
			mySource.Stop ();
			
		}
		
	}
}
