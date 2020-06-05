using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    GameObject cGo;
    public Camera cam;

    void Update()
    {
        cGo = GameObject.Find("PlayerCamera");
       // cam = cGo.GetComponentInChildren<Camera>();
    }

    [SerializeField]Texture2D image;
    [SerializeField]int size;
    [SerializeField]float maxAngle;
    [SerializeField]float minAngle;

    float lookHeight;

    public void LookHeight(float value)
    {
        lookHeight += value;
        if (lookHeight > maxAngle || lookHeight < minAngle)
            lookHeight -= value;
    }


    void OnGUI()
    {
        Vector3 screenPosition = cam.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
        GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y - lookHeight, size, size), image);
    }
}
