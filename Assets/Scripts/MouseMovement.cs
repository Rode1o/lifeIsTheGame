using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public float topClamp = -90f;
    public float botClamp = 90f;
    float xRotation =0f;
    float yRotation = 0f;



    // Start is called before the first frame update
    void Start()
    {
        //locking the cursor
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        // getting mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
         float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

         xRotation -= mouseY;

         xRotation = Mathf.Clamp(xRotation, topClamp, botClamp);

         yRotation += mouseX;
         
         transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        
    }
}
