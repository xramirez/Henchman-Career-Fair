using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour
{
	public GameObject ActiveObject;
    public float speed;
    public float maxSpeed = 2;

	public float turnSpeed = 60;

	private Rigidbody rig;

	float hAxis;
	float vAxis;
	
	bool isgrounded = true;
	bool isholding = false;
	bool translation = false;
	static Animator anim;
	Transform itemTransform;

	// Use this for initialization
	void Start()
	{
		rig = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
        speed = maxSpeed;
	}

	// Update is called once per frame
	void Update()
	{

		hAxis = Input.GetAxis("LeftJoystickH2");
		vAxis = Input.GetAxis("LeftJoystickV2");

	}

	void FixedUpdate()
	{
		Vector3 movement = new Vector3(-hAxis, 0, vAxis);
		transform.Translate(movement * speed * Time.deltaTime, Space.World);
		if(movement != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation(movement);
		}
		if (movement != new Vector3(0, 0, 0))
		{
			translation = true;
		}
		else
		{
			translation = false;
		}
		if (!isgrounded)
		{
			anim.SetBool("IsFalling", true);
		}
		if(isgrounded)
		{
			//print("Not falling");
			anim.SetBool("IsFalling", false);
		}

		/*if (isholding)
		{
			anim.SetTrigger("Holding");
		}
		else
		{
			anim.SetTrigger("NotHolding");
		}*/

		if (translation != false && isgrounded)
		{
			anim.SetBool("isRunning", true);
		}
		else
		{
			anim.SetBool("isRunning", false);
		}

	}

    /*public void Dead()
    {
        speed = 0;
        anim.SetTrigger("Death - Fly Back");
    }

    public void Alive()
    {
        speed = maxSpeed;
        anim.SetTrigger("Death - Fly Back - Done");
    }*/

	//make sure u replace "floor" with your gameobject name.on which player is standing
	void OnCollisionEnter(Collision theCollision)
	{
		if (theCollision.gameObject.tag == "Floor" || theCollision.gameObject.tag == "DropFloor" || theCollision.gameObject.tag == "Player")
		{
			isgrounded = true;
		}

		if (theCollision.collider.tag == "falldeath")
		{
			isgrounded = false;
		}

	}

	void OnCollisionStay(Collision theCollision)
	{
		if (theCollision.gameObject.tag == "Floor" || theCollision.gameObject.tag == "DropFloor" || theCollision.gameObject.tag == "ScoreZone" || theCollision.gameObject.tag == "Player")
		{
			isgrounded = true;
		}
		else
		{
			//print("Hello");
			isgrounded = false;
		}
	}

	
}
