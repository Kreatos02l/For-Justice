using UnityEngine;

public class InputController : MonoBehaviour {

    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool IsJumping;
    public bool IsSprinting;
    public bool IsCrouched;
    public bool IsStrafing;
    public bool IsMoving;
    public bool CastLightning;
    public bool CastShield;
	public bool cMoving;

    void Update()
    {
        Vertical = Input.GetAxis("Horizontal");
        Horizontal = Input.GetAxis("Vertical");

        if (Vertical != 0)
        {
            IsStrafing = true;
        }
        else
            IsStrafing = false;
        if (Horizontal != 0)
            IsMoving = true;
        else
            IsMoving = false;

		if (IsStrafing || IsMoving)
			cMoving = true;
		else
			cMoving = false;
			
        IsJumping = Input.GetKey(KeyCode.Space);
        IsSprinting = Input.GetKey(KeyCode.LeftShift);
        IsCrouched = Input.GetKey(KeyCode.LeftControl);
        CastLightning = Input.GetKey(KeyCode.Alpha2);
        CastShield = Input.GetKey(KeyCode.Alpha1);

        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }
}
