using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour {

	public AudioSource mySource;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift) && GameManager.Instance.InputController.cMoving){

			mySource.Play ();

		} 
		else 
			if(Input.GetKeyUp(KeyCode.LeftShift) && GameManager.Instance.InputController.cMoving)
			{
				mySource.Stop ();

			}
		
	}
}
