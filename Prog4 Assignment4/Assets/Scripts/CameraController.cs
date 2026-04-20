using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform orientation;
    float xRotation, yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yRotation = 135;
        xRotation = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 500;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 500;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
