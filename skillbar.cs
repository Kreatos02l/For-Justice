using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillbar : MonoBehaviour {

	public float cooldown=5;
	bool isCooldown;
	public Image imagecooldown;



	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				isCooldown=true;
			}
		if (isCooldown) 
		{
			imagecooldown.fillAmount += 1 / cooldown * Time.deltaTime;
			if (imagecooldown.fillAmount >= 1) 
			{
				imagecooldown.fillAmount = 0;
				isCooldown = false;
			}
		}


	}

}
