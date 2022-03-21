using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); // y轴是向上的

        Vector3 move = transform.right * x + transform.forward * z; // local 坐标
        controller.Move(move * speed * Time.deltaTime); // delta指相邻帧的相隔时间，如果下一帧是10秒后，那时间会补上来

    }
}
