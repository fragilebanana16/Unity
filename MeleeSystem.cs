using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour
{
    public int Damage = 50;
    public float Distance;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                Distance = hit.distance;
                hit.transform.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}