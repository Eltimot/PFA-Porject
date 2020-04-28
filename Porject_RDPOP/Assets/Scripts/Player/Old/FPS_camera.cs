using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_camera : MonoBehaviour
{
    [Header("Camera")]
    public float mouseSensitivity;
    public Transform PlayerBody;
    public Transform CameraHolder;

    //Rotation and look
    private float xRotation;
    //private float sensitivity = 50f;
    //private float sensMultiplier = 1f;

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        PlayerBody.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        CameraHolder.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        /*

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * sensMultiplier;

        //Find current look rotation
        Vector3 rot = CameraHolder.transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;

        //Rotate, and also make sure we dont over- or under-rotate.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        CameraHolder.transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
        orientation.transform.localRotation = Quaternion.Euler(0, desiredX, 0);*/
    }
}
