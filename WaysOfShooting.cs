using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaysOfShooting : MonoBehaviour
{
    private string info = "Dada";
    public Transform objToBeAttachedToHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // --------------Shoot with ray cast, instantiate obj on hit surface------------------------
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3((int)((double)Screen.width *0.5), (int)((double)Screen.height * 0.5) , 0)); // Center of screen as start 
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.green); // from screen center to the edge
                Debug.Log("hit:" + hit.transform.name);
                var temp = Instantiate(objToBeAttachedToHit, hit.point, Quaternion.LookRotation(hit.normal)); // instantiate at point with the normal direction
                Destroy(temp.gameObject, 2); // destroy after 2s
                hit.transform.SendMessage("TestSendMsg", info, SendMessageOptions.DontRequireReceiver); // On other script write TestSendMsg()
            }
        }
    }
}
