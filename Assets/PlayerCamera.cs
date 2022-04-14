using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    // Code referenced from "Dave / GameDevelopment"
    // https://www.youtube.com/watch?v=f473C43s8nE

    public float xSensitivity;
    public float ySensitivity;
    private float xRotation;
    private float yRotation;

    public Transform orientation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        float xMotion = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float yMotion = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        yRotation += xMotion;
        //yRotation = Mathf.Clamp(yRotation, 90f, 270f);

        xRotation -= yMotion;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
     }
}
