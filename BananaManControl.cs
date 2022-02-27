using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaManControl : MonoBehaviour
{
    /// <summary>
    /// Enemy animator
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Enemy move speed
    /// </summary>
    public float speed = 1f;

    /// <summary>
    /// Enemy dead
    /// </summary>
    public bool isDead = false;

    /// <summary>
    /// The player
    /// </summary>
    public Transform target;

    /// <summary>
    /// Player distance with this
    /// </summary>
    public float distance;

    /// <summary>
    /// Look at distance
    /// </summary>
    public float lookAtDistance = 25.0f;

    /// <summary>
    /// Chase distance
    /// </summary>
    public float chaseDistance = 15.0f;

    public float damping = 6.0f;

    public CharacterController controler;

    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;

    public float moveSpeed = 5.0f;

    public float attackRange = 3.0f;

    private float attackTime;

    private float attackRepeatime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0.3f);
        Debug.Log("set to walk");
        this.attackTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.distance = Vector3.Distance(target.position, transform.position);
        if(this.distance < this.lookAtDistance)
        {
            anim.SetFloat("speed", 0.1f);
            this.LookAt();
        }


        if(this.distance > this.lookAtDistance)
        {
            anim.SetFloat("speed", 0.1f);
            transform.Find("Body").GetComponent<SkinnedMeshRenderer>().material.color = Color.green;
        }

        if (this.distance < this.attackRange)
        {
            this.Attack();
        }
        else if(this.distance < this.chaseDistance)
        {
            anim.SetFloat("speed", 0.3f);
            this.Chase();
        }

        // ************* Following code translate will pass through object while chasing *********
        // if (!isDead)
        // {
        //     transform.Translate (Vector3.forward * speed * Time.deltaTime); // move forward
        // }
        // else{
        //     transform.Translate (Vector3.zero); // stop movement
        // }
        // ****************************************************************************************
    }

    private void LookAt(){
        transform.Find("Body").GetComponent<SkinnedMeshRenderer>().material.color = Color.yellow;
        var rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    private void Chase(){
        transform.Find("Body").GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
        this.moveDirection = transform.forward;
        this.moveDirection *= moveSpeed;

        this.moveDirection.y -= this.gravity * Time.deltaTime;
        this.controler.Move(this.moveDirection * Time.deltaTime);
    }

    private void Attack(){
        // for example, 0.1 > 0; attacktime=1.1; 1.2>1.1; attacktime=2.1; so each repeatTime this if will enter
        if (Time.time > this.attackTime)
        {
            this.attackTime = Time.time + this.attackRepeatime;
            Debug.Log("Attack");
        }
    }
}
