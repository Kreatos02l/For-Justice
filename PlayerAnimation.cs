using UnityEngine;
using System.Collections;


public class PlayerAnimation : MonoBehaviour {

    Animator animator;

    void Awake () {
        animator = GetComponentInChildren<Animator>();	
	}


	void Update () {

        animator.SetFloat("Vertical", GameManager.Instance.InputController.Horizontal);
        animator.SetFloat("Horizontal", GameManager.Instance.InputController.Vertical);
        
        
        animator.SetBool("IsJumping", GameManager.Instance.InputController.IsJumping);
        animator.SetBool("IsSprinting", GameManager.Instance.InputController.IsSprinting);
        animator.SetBool("IsCrouched", GameManager.Instance.InputController.IsCrouched);
        animator.SetBool("IsStrafing", GameManager.Instance.InputController.IsStrafing);
        animator.SetBool("IsMoving", GameManager.Instance.InputController.IsMoving);

		StartCoroutine ("animCD");
    }

	IEnumerator animCD(){
		animator.SetBool("CastLightning", GameManager.Instance.InputController.CastLightning);
		animator.SetBool("CastShield", GameManager.Instance.InputController.CastShield);

		yield return new WaitForSeconds(5);		
	}
}
