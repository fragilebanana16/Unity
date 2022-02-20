/// <summary>
/// Bullet damage manager
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    /// <summary>
    /// Bullet damage
    /// </summary>
    public float bulletDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// On Collion send msg to the collided object
    /// </summary>
    /// <param name="other">collided object</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.transform.SendMessage("ApplyDamage", this.bulletDamage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
