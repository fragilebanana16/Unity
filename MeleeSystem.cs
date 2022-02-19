/// <summary>
/// MeleeSystem, attach to an empty object
/// </summary>
using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour
{
    /// <summary>
    /// Each hit damage done
    /// </summary>
    public int damage = 50;

    /// <summary>
    /// Show on ui indicating how long is the ray cast distance
    /// </summary>
    public float raycastDistance;

    /// <summary>
    /// Max hit distance
    /// </summary>
    public float maxAttackDistance = 20f;

    /// <summary>
    /// Get hit direction
    /// </summary>
    public Camera mainCam;

    public Animator anim;
    void Start()
    {
        this.anim = transform.parent.gameObject.GetComponent<Animator>(); // get PlayerArmature animator
    }
    void Update()
    {
        bool attackRet = anim.GetBool("AttackFinshed"); // FIXME:wait until animation finshed? 
 
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("RightHandAttack", true);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, mainCam.transform.TransformDirection(Vector3.forward), out hit))
            {
                raycastDistance = hit.distance;

                if (raycastDistance < this.maxAttackDistance)
                {
                    hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
                    Debug.DrawLine(transform.position, mainCam.transform.TransformDirection(Vector3.forward), Color.red, 1f);
                }
            }
        }
        else
        {
            anim.SetBool("RightHandAttack", false);
        }

    }
}