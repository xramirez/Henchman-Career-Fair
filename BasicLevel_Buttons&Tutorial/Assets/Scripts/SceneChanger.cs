using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public bool panelsEnabled;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		panelsEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Start"))
        {
			panelsEnabled = false;
			Time.timeScale = 1;
			GameObject.Find("Panel1").SetActive(false);
			GameObject.Find("Panel2").SetActive(false);
			GameObject.Find("Panel3").SetActive(false);
			GameObject.Find("Panel4").SetActive(false);
			//this.GetComponent<ControllerSelectionMenu>().enabled = false;
			this.GetComponent<SceneChanger>().enabled = false;
		}
	}
}
