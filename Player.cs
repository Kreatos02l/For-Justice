using UnityEngine;

public class Player : MonoBehaviour {

    InputController inputController;
    //Camera cam;

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }

    [SerializeField]float runSpeed;
    [SerializeField]float sprintSpeed;
    [SerializeField]float crouchSpeed;
    [SerializeField]MouseInput MouseControl;
    public float moveSpeed;

    public float downAccel = 0.75f;
    public float jPower = 25f;
    public float distToGrounded = 0.1f;
    public LayerMask ground;

    Quaternion targetRotation;
    Rigidbody rBody;
    Vector3 velocity = Vector3.zero;

    private float Vertical;
    private float Horizontal;
    private bool IsJumping;
    private bool IsSprinting;
    private bool IsCrouched;

    private float rotY;
    public float cAngleUp;
    public float cAngleDown;


    public Quaternion TargetRotation
    {
        get
        {
            return targetRotation;
        }
    }

    public float Speed
    {
        get
        {
            return runSpeed;
        }

        set
        {
            runSpeed = value;
        }
    }

    void Start()
    {
        targetRotation = transform.rotation;

        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else

            Debug.LogError("The character needs a rigidbody.");
        Vertical = Horizontal = 0;

        //cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();

    }

    private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }


    void Update()
    {

        Vertical = playerInput.Vertical;
        Horizontal = playerInput.Horizontal;

        IsCrouched = playerInput.IsCrouched;
        IsSprinting = playerInput.IsSprinting;
        IsJumping = playerInput.IsJumping;

        LookAround();
    }


    void FixedUpdate()
    {
        Move();
        Jumping();
        rBody.velocity = velocity;

              
    }


    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;

       // if (MouseControl.LockMouse)
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
       // }
    }
    InputController playerInput;
    Vector2 mouseInput;

    public Camera pcam;


    void LookAround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y * 6.7f);

        rotY += mouseInput.y * MouseControl.Sensitivity.y;

        rotY = Mathf.Clamp(rotY, -cAngleDown, cAngleUp);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        Quaternion localRotation = Quaternion.Euler(Vector3.right * -rotY);

        //pcam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        pcam.transform.localRotation = localRotation;
    }


    void Move()
    {
        moveSpeed = runSpeed;
        if (IsSprinting)
        {
            moveSpeed = sprintSpeed;
        }
            
        if (IsCrouched)
        {
            moveSpeed = crouchSpeed;
        }

        Vector2 direction = new Vector2(Horizontal * moveSpeed, Vertical * moveSpeed);

        transform.position += transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime;
    }


    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGrounded, ground);
    }


    bool IsStrafing()
    {
        if (GameManager.Instance.InputController.Vertical != 0.0f)
            return true;
        return false;
    }

    bool IsMoving()
    {
        if (GameManager.Instance.InputController.Horizontal != 0.0f)
            return true;
        return false;
    }

    void Jumping()
    {
        if (!IsCrouched && IsMoving())
        {
            if (IsJumping && Grounded())
            {
                if (GameManager.Instance.InputController.Horizontal >= 0 && !IsStrafing())
                {
                    if (IsSprinting)
                        velocity.y = jPower * 1.5f;
                    else { 
                    velocity.y = jPower;
                    }
                }

                else
                    velocity.y = 0;
            }
            else if (!IsJumping && Grounded())
            {
                //Zero out
                velocity.y = 0;
            }
            else
            {
                //Decreasing
                velocity.y -= downAccel;
            }
            
        }
        else
            velocity.y = 0;
    }
}
