using UnityEngine;
using System.Collections;

public class EmmitersSetup : MonoBehaviour {

    public Transform emmiterLeft;
    public Transform emmiterRight;
    private float cameraWidth;
    
	void Start () 
    {
        if (emmiterLeft != null && emmiterRight != null)
        {
            GetCameraWidht();
            SetEmmitersPosition();
        }
        else
        {
            Debug.LogError("emmiters are not set");
        }
	}

    void GetCameraWidht()
    {
        float height = Camera.main.orthographicSize * 2;
        cameraWidth = height * Camera.main.aspect;
    }

    void SetEmmitersPosition()
    {
        Vector3 emmiterLeftPos = transform.position;
        Vector3 emmiterRightPos = transform.position;
        emmiterLeftPos.x -= (cameraWidth / 2);
        emmiterRightPos.x += (cameraWidth / 2);
        emmiterLeft.position = emmiterLeftPos;
        emmiterRight.position = emmiterRightPos;
    }
}
