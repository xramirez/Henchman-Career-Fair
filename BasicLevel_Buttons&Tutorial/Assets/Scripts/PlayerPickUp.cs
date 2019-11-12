using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUp : MonoBehaviour {
    public int PickupValue = 0;
    public bool HasObject = false;
    bool respawn;
    public int points = 0;
    public Vector3 StartPosition; 
    float playerRespawn = 0;
    float respawnCooldown = 3f;
    public GameObject collectedObject;
    public string collectedName;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    string playerNumber;
	GameObject looker;
    Image winDisplay;

	private Rigidbody rig;

	private Animator anim;
	Transform itemTransform;

	AudioSource sound;
    [SerializeField]
    AudioSource scoreSound;

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "coin" && HasObject == false)
        {
			//GetComponentInChildren<punching>().canPunch = false;
			PickupValue = collision.collider.GetComponent<SphereValues>().PointValue;
            collectedName = collision.collider.name;
            //collectedPosition = collision.collider.transform.position;
            collectedObject = GameObject.Find(collectedName);
            collectedObject.transform.position = transform.position + new Vector3(0, 0.36f, 0);
			collectedObject.GetComponent<Collider>().enabled = false;
			HasObject = true;
			/*for animation of pickup*/
			itemTransform = collision.transform;
			itemTransform.transform.parent = transform;
            //itemTransform.transform.position = collectedObject.transform.position;
            /**/
        }

		if (collision.collider.tag == "ScoreZone")
        {
            if(HasObject)
            {
                points += PickupValue;
                scoreText.text = points.ToString("0000");
                itemRespawn();
                scoreSound.Play();
			}
            if(points >= 10)
            {
                looker.GetComponent<CoolHolder>().gameOver = true;
                looker.GetComponent<CoolHolder>().timeStamp = Time.time;
                GetComponent<XboxInput>().celebrating = true;
                //Time.timeScale = 0;
                winDisplay.enabled = true;
            }
        }
        if (collision.collider.tag == "SawBlade" || collision.collider.tag == "NeedleSpike" || collision.collider.tag == "Fire")
        {
            //print("collision");
            transform.position = new Vector3(0, 1000, 0);
            //this.gameObject.GetComponent<PlayerController2>().Dead();
			GetComponent<Rigidbody>().useGravity = false;
			if (HasObject)
            {
                itemRespawn();
			}

            startRespawn();


        }
        if (collision.collider.tag == "falldeath")
        {
			
			
			transform.position = new Vector3(0, 1000, 0);
			GetComponent<Rigidbody>().useGravity = false;
            if (HasObject)
            {
                itemRespawn();
			}

            startRespawn();
        }
    }   

	public void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "SawBlade" || collision.tag == "NeedleSpike" || collision.tag == "Fire")
		{
			print("hey");
			//print("collision");
			transform.position = new Vector3(0, 1000, 0);
			//this.gameObject.GetComponent<PlayerController2>().Dead();
			GetComponent<Rigidbody>().useGravity = false;
			if (HasObject)
			{
				print("hah");
				itemRespawn();
			}

			startRespawn();
		}
	}

    // Use this for initialization
    void Start () {
        StartPosition = transform.position;
        points = 0;
        scoreText.text = points.ToString("0000");
        winDisplay = GameObject.Find("Player " + playerNumber + " Wins").GetComponent<Image>();
        winDisplay.enabled = false;
        looker = GameObject.Find("CooldownHolder");
        respawn = false;
		rig = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		anim.SetTrigger("NotHolding");
		sound = GetComponent<AudioSource>();
	}

    public void startRespawn()
    {
		sound.Play();
        playerRespawn = Time.time + respawnCooldown;
        respawn = true;
    }

    public void itemRespawn()
    {
		print("heh");
        itemTransform.transform.parent = null;
        collectedObject.transform.position = new Vector3(20, 1000, 0);
        collectedObject.GetComponent<SphereValues>().startRespawn();
        collectedObject.GetComponent<Collider>().enabled = true;
        HasObject = false;
        PickupValue = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(respawn == true)
        {
            if(Time.time >= playerRespawn)
            {
                transform.position = StartPosition + new Vector3(0,1,0);
				GetComponent<Rigidbody>().useGravity = true;
                respawn = false;
            }
        }

		if (HasObject)
		{
			//print("I have an Object");
			anim.ResetTrigger("NotHolding");
			anim.SetTrigger("Holding");
            //GetComponentInChildren<punching>().canPunch = false;
        }
		else
		{
			anim.ResetTrigger("Holding");
			anim.SetTrigger("NotHolding");
            //GetComponentInChildren<punching>().canPunch = true;
        }
	}
}
