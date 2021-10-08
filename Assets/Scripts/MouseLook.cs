﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //quito el cursor de la pantalla
    }

    // Update is called once per frame
    void Update() {
        float mouseX = Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime;

       // xRotation -= mouseY;
        yRotation += mouseX;
       // xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
