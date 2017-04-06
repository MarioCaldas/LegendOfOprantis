using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{

    private const float Y_ANGLE_MIN = 15.0f;
    private const float Y_ANGLE_MAX = 50.0f;


    public Transform lookAt;
    public Transform camTransfrom;

    private Camera Cam;

    private float distance = 4.0f;

    private float currentX = 0.0f;

    private float currentY = 0.0f;

    private float sensivityY = 25.0f;

    private float sensivityX = 25.0f;

    
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);


        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransfrom.position = lookAt.position + rotation * dir;
        camTransfrom.LookAt(lookAt.position + Vector3.up * 2);


        if (Input.GetMouseButton(1))
        {


        }

    }


}