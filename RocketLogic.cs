using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLogic : MonoBehaviour
{
    private bool isDrawUI = false;

    public Vector3 pickUpRotation;
    public Vector3 pickUpPosition;

    public bool isRocketOn = false;
    public Transform rocketParent;
    public Transform player;


    public float flyForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isDrawUI && Input.GetKeyDown(KeyCode.E))
        {
            // attacj rocket to spine
            transform.parent = rocketParent;
            transform.localPosition = this.pickUpPosition;
            transform.localEulerAngles = this.pickUpRotation;
            // disable collider to fix camera view
            GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.Find("Rocket1").GetComponent<CapsuleCollider>().enabled = false;
            gameObject.transform.Find("Rocket2").GetComponent<CapsuleCollider>().enabled = false;
            this.isRocketOn = true;
            this.isDrawUI = false;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Rocket working");
            this.isDrawUI = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.isDrawUI = false;
        }
    }

    
    private void OnGUI()
    {
        if (this.isDrawUI)
        {
            GUI.Box(new Rect (Screen.width*0.5f - 51, 200, 102, 22), "Press E to Fly");
        }
    }
}
