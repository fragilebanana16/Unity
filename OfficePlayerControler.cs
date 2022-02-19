using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class OfficePlayerControler : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit Point" + hit.point);
                agent.SetDestination(hit.point);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Change Scene");
            SceneManager.LoadScene("SampleScene");
        }
    }

}
