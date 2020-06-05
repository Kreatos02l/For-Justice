using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]float damping = 15.0f;
    [SerializeField]public Vector3 Posoffset;
    [SerializeField]private Space offsetPositionSpace = Space.Self;

    public Transform cameraLookTarget;
    Player localPlayer;

    public float mouseX;
    public float mouseY;
    private float rotY;
    private float rotX;
    public float inputSensitivity = 3.0f;

    public float cAngleUp = 130;
    public float cAngleDown=30;

    [SerializeField]
    private bool lookAt = true;


    public float Rotoffset;

    void Awake () {
       GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("CameraFocus");
       if (cameraLookTarget == null)
            cameraLookTarget = localPlayer.transform;
    }

    void Start()
    {
        //Posoffset = transform.position - cameraLookTarget.transform.position;
    }
    void LateUpdate () {

        Refresh();
        camRot();

    }

    void camRot()
    {

        if (lookAt)
        {
            transform.LookAt(cameraLookTarget);
        }
        else
        {
           transform.rotation = cameraLookTarget.rotation;
        }

    }

    void Refresh()
    {
        if (cameraLookTarget == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = cameraLookTarget.TransformPoint(Posoffset);
        }
        else
        {
            transform.position = cameraLookTarget.position + Posoffset;
        }
    }
}
