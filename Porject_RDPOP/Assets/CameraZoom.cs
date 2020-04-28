using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetAxis("Scroll") > 0f) // forward
        {
            cam.orthographicSize++;
        }
        else if (Input.GetAxis("Scroll") < 0f) // backwards
        {
            cam.orthographicSize--;
        }
    }
}
