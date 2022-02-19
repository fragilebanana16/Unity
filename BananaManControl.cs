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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0.3f);
        Debug.Log("set to walk");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            transform.Translate (Vector3.forward * speed * Time.deltaTime); // move forward
        }
        else{
            transform.Translate (Vector3.zero); // stop movement
        }
    }


}
