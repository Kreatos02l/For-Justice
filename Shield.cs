using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public GameObject myOwner;
	public float duration;
	float timer;

	void Start () {
		timer = duration;
	}

	void Update () {
		timer -= Time.deltaTime;

		transform.position = myOwner.transform.position;

		if (timer <= 0) {
			Death();
		}
	}

	public void Death(){
		Destroy(gameObject);
	}
}
