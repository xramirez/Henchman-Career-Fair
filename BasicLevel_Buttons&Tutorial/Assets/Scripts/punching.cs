using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punching : MonoBehaviour {
    public GameObject PunchingPlayer;
    public string PunchButton;
	[SerializeField]
    bool Punching;
    public bool canPunch;
    public float PunchDuration;
    float PunchTimeStamp;
    float StunTime;
	string PunchedObjectName;
	GameObject PunchedObject;
	float CurrentTime;
	Collider hitbox;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Punching = false;
            hitbox.enabled = false;
        }
    }

    void Start () {
        Punching = false;
		hitbox = GetComponent<Collider>();
		hitbox.enabled = false;
        canPunch = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown(PunchButton) && canPunch == true)
        {
            Punching = true;
			canPunch = false;
            PunchTimeStamp = Time.time; 
        }
        /*if(Punching)
        {
            this.transform.position = PunchingPlayer.transform.forward + PunchingPlayer.transform.position;
            this.transform.rotation = PunchingPlayer.transform.rotation;
        }*/
        
	}

	void FixedUpdate()
	{
		if (Punching)
		{
			PunchingPlayer.GetComponent<XboxInput>().speed = 0;
			hitbox.enabled = true;
			PunchingPlayer.GetComponent<XboxInput>().Attacking = true;
		}
		if (GetComponentInParent<PlayerPickUp>().HasObject  || GetComponentInParent<XboxInput>().isPunched)
		{
			canPunch = false;
		}
		else
		{
			if(Time.time >= PunchTimeStamp + PunchDuration)
			{
				canPunch = true;
				Punching = false;
				hitbox.enabled = false;
				PunchingPlayer.GetComponent<XboxInput>().speed = 1.5f;
				PunchingPlayer.GetComponent<XboxInput>().Attacking = false;
				//this.transform.position = new Vector3(100, 100, 100);
			}
		}
	}
}
