using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // hide cursor
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 限制上下角度

        // 上下只转Camera左右需要转整体
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // up down rotate, 也可以像下一行这样转，但是就没法控制clamp了
        // playerBody.Rotate(Vector3.right * mouseY); // left right rotate, up represents y axis
        playerBody.Rotate(Vector3.up * mouseX); // left right rotate, up represents y axis
    }
}
