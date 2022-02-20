/// <summary>
/// Enemy health system
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaManHealthSystem : MonoBehaviour
{
    /// <summary>
    /// Enemy animator
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Enemy health
    /// </summary>
    public int health = 100;

    /// <summary>
    /// Script that control the banana man move ctrl
    /// </summary>
    private BananaManControl bananaManCtrl;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bananaManCtrl = GetComponent<BananaManControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            this.Dead();
        }
    }

    /// <summary>
    /// Once got msg, play animation
    /// </summary>
    /// <param name="damage">damage</param>
    void ApplyDamage(int damage)
    {
        health -= damage;
        anim.SetBool("takeDmg", true);
        Debug.Log("banana man takeDmg"); //FIXME:Damage Animation not working
        anim.SetBool("takeDmg", false);
    }

    /// <summary>
    /// Dead
    /// </summary>
    void Dead()
    {
        anim.SetBool("dead", true); // change to death animation
        bananaManCtrl.isDead = true; // stop movement
    }
}
