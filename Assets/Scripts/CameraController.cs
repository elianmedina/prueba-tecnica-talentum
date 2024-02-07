using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 2f; 

    private void Start()
    {
        Cursor.visible = false; 
    }

    private void Update()
    {
        float rotX = transform.eulerAngles.x;
        float rotY = transform.eulerAngles.y;

        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        rotY += mouseX * sensitivity;
        rotX -= mouseY * sensitivity;

        rotX = Mathf.Clamp(rotX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0f);

        transform.LookAt(player.position);
    }
}
