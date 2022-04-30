using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeadContr : MonoBehaviour
{
    public CharacterController contr;
    public Transform playerBody;
    public Camera cam;
    float xRotation = 0f;
    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        contr.Move(playerBody.forward * vertical * 12f * Time.deltaTime);
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        xRotation = xRotation - mouseY;
        xRotation = Math.Clamp(xRotation,-90f,90f);
        playerBody.Rotate(0,mouseX,0);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        float horizontal = Input.GetAxis("Horizontal");
        contr.Move(playerBody.right * speed * horizontal * Time.deltaTime);

        
    }
}
