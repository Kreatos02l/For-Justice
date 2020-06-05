using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillbar2 : MonoBehaviour {

	public float cooldown=5;
	bool isCooldown;
	public Image imagecooldown1;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			isCooldown=true;
		}
		if (isCooldown) 
		{
			imagecooldown1.fillAmount += 1 / cooldown * Time.deltaTime;
			if (imagecooldown1.fillAmount >= 1) 
			{
				imagecooldown1.fillAmount = 0;
				isCooldown = false;
			}
		}
	}
}
