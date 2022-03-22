using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedPlayerMovement : MonoBehaviour
{
    /// <summary>
    /// 玩家控制组件用于Move，拖拽到编辑面板的该属性上
    /// </summary>
    public CharacterController controller;

    /// <summary>
    /// controller移动速度
    /// </summary>
    public float speed = 12f;

    /// <summary>
    /// 模拟重力
    /// </summary>
    public float gravity = -9.81f;

    /// <summary>
    /// 底部用于检测是否落地的gameobj
    /// </summary>
    public Transform groundCheck;

    /// <summary>
    /// 底部用于检测是否落地的gameobj生成的sphere半径
    /// </summary>
    public float groundDistance = 0.4f;

    /// <summary>
    /// 面板groundMask设置为地面，检测时一旦相同，CheckSphere返回true
    /// </summary>
    public LayerMask groundMask;

    /// <summary>
    /// 下落速度
    /// </summary>
    private Vector3 velocity;

    /// <summary>
    /// 跳跃高度
    /// </summary>
    private float jumpHeight = 4f;

    /// <summary>
    /// 落地标志
    /// </summary>
    private bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        this.isGrounded = Physics.CheckSphere(this.groundCheck.position, this.groundDistance, this.groundMask); // 底部放置一个obj groundCheck，生成一个半径为groundDistance的球体判断groundMask是不是ground（编辑器中设置地面tag）
        
        if (this.isGrounded && this.velocity.y < 0)
        {
            this.velocity.y = -2f; // -2是测试出较好的值，按道理应该是0，但是前面检测时可能设为0会产生缝隙
        }

        this.speed = this.isGrounded ? 12f : 3f; // 跳起来移动速度应该减少
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); // y轴是向上的

        // 模拟移动x，z轴的移动
        Vector3 move = transform.right * x + transform.forward * z; // local 坐标
        controller.Move(move * speed * Time.deltaTime); // delta指相邻帧的相隔时间，如果下一帧是10秒后，那时间会补上来

        // 模拟下落
        this.velocity.y += this.gravity * Time.deltaTime; // 将一直减少
        controller.Move(this.velocity * Time.deltaTime); // 模拟下落，和用rb区别是什么

        if (Input.GetButtonDown("Jump"))
        {
            this.velocity.y = Mathf.Sqrt(this.jumpHeight * -2f * this.gravity); // v = √(-2gh) 是根据 h = 1/2 gt方 和 v=gt联立消除t得出的
        }
    }
}
