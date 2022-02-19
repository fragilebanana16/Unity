using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool currentInPauseState = false;
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pauseUI.SetActive(currentInPauseState);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentInPauseState = !currentInPauseState;
            Debug.Log("currentInPauseState:" + currentInPauseState.ToString());
        }
    }

    public void OnResuemeClicked(){
        Debug.Log("Resume!");
        pauseUI.SetActive(false);
        currentInPauseState = false;
    }

    public void OnExitClicked(){
        Application.Quit();
    }
}
