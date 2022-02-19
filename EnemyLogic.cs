/// <summary>
/// Enemy Melee Logic, attch to enemy
/// </summary>
using UnityEngine;
using System.Collections;
 
public class EnemyLogic : MonoBehaviour {

    /// <summary>
    /// Enemy health
    /// </summary>
    public int health = 100;
 
    void Update()
    {
        if (health <= 0)
        {
            Dead();
        }
    }

    /// <summary>
    /// MeleeSystem::hit.transform.SendMessage will call this
    /// </summary>
    /// <param name="damage">damage</param>
    void ApplyDamage(int damage)
    {
        health -= damage;
    }

    /// <summary>
    /// Destory gameobject
    /// </summary>
    void Dead()
    {
        Destroy (gameObject);
    }
}