using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLogic : MonoBehaviour
{
    private bool bridgeMoving = false;

    public float bridgeMovingSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.bridgeMoving)
        {
            transform.parent.Translate((Vector3.back * this.bridgeMovingSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Bridge working");
            this.bridgeMoving = true;
        }
    }
}
