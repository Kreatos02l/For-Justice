using UnityEngine;

public class CameraCollision : MonoBehaviour {

    public float minDistance = 0.1f;
    public float maxDistance = 0.5f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;

    public Transform cameraLookTarget;
    public Player localPlayer;

	// Use this for initialization
	void Awake () {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("CameraFocus");
        if (cameraLookTarget == null)
            cameraLookTarget = localPlayer.transform;
    }

    // Update is called once per frame
    void Update () {

        Vector3 desiredCameraPos = transform.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if(Physics.Linecast (transform.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp ((hit.distance * 0.87f), minDistance, maxDistance);
            distance = minDistance;
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	
	}
}
