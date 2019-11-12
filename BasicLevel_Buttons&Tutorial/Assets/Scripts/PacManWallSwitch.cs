using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManWallSwitch : MonoBehaviour {

	private Rigidbody rig;
	GameObject leftside;
	GameObject rightside;
	Vector3 transportation = new Vector3(0, 0, 0);
	Vector3 transEdit = new Vector3(1f, 0, 0);

	// Use this for initialization
	void Start()
	{
		rig = GetComponent<Rigidbody>();
		leftside = GameObject.FindGameObjectWithTag("LeftWall");
		rightside = GameObject.FindGameObjectWithTag("RightWall");
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "LeftWall")
		{
			transportation = rightside.transform.position - transEdit;
			transportation.y = transform.position.y + .000001f;
			transform.position = transportation;
		}
		if(collision.collider.tag == "RightWall")
		{
			transportation = leftside.transform.position + transEdit;
			transportation.y = transform.position.y + .000001f;
			transform.position = transportation;
		}
	}
}
