using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = other.GetComponent<PlayerPickUp>().StartPosition;
            other.GetComponent<PlayerPickUp>().HasObject = false;
        }
    }
}
