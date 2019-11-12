using UnityEngine;
using System.Collections;

public class XboxInput : MonoBehaviour
{
    public GameObject ActiveObject;
    [SerializeField]
    public float speed;

    float hAxis;
    float vAxis;
    public float turnSpeed = 60;
    public bool movementEnabled;
    bool isgrounded = true;
    bool isholding = false;
    bool translation = false;
    public bool celebrating;
    private Animator anim;
    Transform itemTransform;
    private Rigidbody rig;
    public int id;
    public KeyCode A, B, X, Y, BStart, Select, LR, LT;
	public bool isPunched;
	public bool Attacking;
    float currentTime;
    float StunTime = 2;
    GameObject looker;

    public void Start()
    
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        A = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + id+ "Button0");
        B = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + id + "Button1");
        X = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + id + "Button2");
        Y = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + id + "Button3");
        LT = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + id + "Button4");
        LR = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + id + "Button5");
        Select = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + id + "Button6");
        BStart = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick" + id + "Button7");
		isPunched = false;
		Attacking = false;
        movementEnabled = false;
        looker = GameObject.Find("CooldownHolder");
    }
    public void Update()
    {
        if(movementEnabled)
        {
            hAxis = Input.GetAxis("LeftJoystickH" + id);
            vAxis = Input.GetAxis("LeftJoystickV" + id);
        }
    }

    void FixedUpdate()
    {
        if(movementEnabled)
        {
            Vector3 movement = new Vector3(-hAxis, 0, vAxis);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            if (movement != Vector3.zero)
            {
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
        }

        if (!isgrounded)
        {
            anim.SetBool("IsFalling", true);
        }
        if (isgrounded)
        {
            //print("Not falling");
            anim.SetBool("IsFalling", false);
        }

        if (translation != false && isgrounded)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

		if (isPunched)
		{
            if(Time.time >= currentTime + StunTime)
            {
                isPunched = false;
                movementEnabled = true;
                //GetComponentInChildren<punching>().canPunch = true;
            }
		}
		else
		{
			anim.SetTrigger("NotStunned");
		}

		if(Attacking)
		{
			anim.ResetTrigger("NotPunching");
			anim.SetTrigger("Punching");
		}
		else
		{
			anim.ResetTrigger("Punching");
			anim.SetTrigger("NotPunching");
		}

        if(looker.GetComponent<CoolHolder>().gameOver == true && celebrating)
        {
            movementEnabled = false;
            anim.SetBool("Dance - Twerk", true);
        }
        else if(looker.GetComponent<CoolHolder>().gameOver == true && celebrating == false)
        {
            movementEnabled = false;
            anim.SetBool("Defeat", true);
        }
    }

	//make sure u replace "floor" with your gameobject name.on which player is standing
	void OnCollisionEnter(Collision theCollision)
	{
		if (theCollision.gameObject.tag == "Floor" || theCollision.gameObject.tag == "DropFloor" || theCollision.gameObject.tag == "Player")
		{
			isgrounded = true;
		}

		if (theCollision.collider.tag == "falldeath" || theCollision.collider.tag == "SawBlade" || theCollision.collider.tag == "NeedleSpike" || theCollision.collider.tag == "Fire")
		{
			isgrounded = false;
		}
    }

	/*void OnCollisionStay(Collision theCollision)
	{
        if (theCollision.gameObject.tag == "Floor" || theCollision.gameObject.tag == "DropFloor" || theCollision.gameObject.tag == "ScoreZone" || theCollision.gameObject.tag == "Player")
		{
			isgrounded = true;
		}
		else
		{
			isgrounded = false;
		}
	}*/

    private void OnTriggerEnter(Collider theCollider)
    {
        if (theCollider.tag == "PunchBox")
        {
            print(this.gameObject.name + " Punched");
            movementEnabled = false;
            anim.SetTrigger("Stunned");
            //GetComponentInChildren<punching>().canPunch = false;
            isPunched = true;
            if (GetComponent<PlayerPickUp>().HasObject)
            {
                GetComponent<PlayerPickUp>().itemRespawn();
            }

            currentTime = Time.time;
        }
		if (theCollider.tag == "falldeath" || theCollider.tag == "SawBlade" || theCollider.tag == "NeedleSpike" || theCollider.tag == "Fire")
		{
			isgrounded = false;
		}
	}
}

