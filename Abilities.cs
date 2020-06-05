using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {

	public Texture2D abilityIcon;
	public GameObject shield;

	void Start () {

	}

	void Update () {

		bool AB1 = Input.GetKeyDown (KeyCode.Alpha1);

		if (AB1) {
			Ability1();
		}

	}

	void OnGUI(){
		GUI.DrawTexture (new Rect (10, 150, abilityIcon.width, abilityIcon.height), abilityIcon);
	}

	void Ability1(){
		GameObject myShield = (GameObject)Instantiate (shield, transform.position, shield.transform.rotation);
		Shield shieldScript = myShield.GetComponent<Shield> ();
		shieldScript.myOwner = this.gameObject;
	}
}
