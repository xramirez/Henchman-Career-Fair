using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public bool paused;

	// Use this for initialization
	void Start () {
        pauseMenuUI.SetActive(false);
        paused = false;		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Start"))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        Debug.Log("Resuming game");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Debug.Log("Quitting game");
        SceneManager.LoadScene("Menu");
    }
}
