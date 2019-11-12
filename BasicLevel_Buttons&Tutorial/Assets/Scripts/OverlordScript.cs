using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlordScript : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 10f;
    bool trapactive = false;
    float difference = 0;
    float fireTrigger;
    Vector3 startPosition;
    Animator anim;
    private ParticleSystem ps;

    [SerializeField]
    bool durationComplete;
    [SerializeField]
    float duration = 3;
	float durationTimeStamp;
    Collider m_collider;
    [SerializeField]
    string trapType;
    [SerializeField]
    string trapInput;
    [SerializeField]
    string dropTrapRow;
    GameObject looker;
	AudioSource sound;

	// Use this for initialization
	void Start()
    {
		sound = GetComponent<AudioSource>();
		startPosition = transform.position;
        looker = GameObject.Find("CooldownHolder");
        looker.GetComponent("CoolHolder");
        trapType = gameObject.tag;//gets trap type so it knows which input activates it
        //m_collider = GetComponent<Collider>();
        //m_collider.enabled = true;
        if(trapType == "Needle")
        {
            m_collider = gameObject.transform.Find("Needle").GetComponent<Collider>();
            m_collider.enabled = false;
            anim = gameObject.GetComponent<Animator>();
        }
        if(trapType == "Saw")
        {
            m_collider = gameObject.transform.Find("SawBlade").GetComponent<Collider>();
            m_collider.enabled = false;
            anim = gameObject.GetComponent<Animator>();
        }
        if(trapType == "Fire")
        {
            m_collider = GetComponent<Collider>();
            ps = GetComponent<ParticleSystem>();
            m_collider.enabled = false;
        }
        //print(trapInput);
		durationComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
        //fireTrigger = Input.GetAxis(trapInput);
        if (Input.GetButtonDown(trapInput) && looker.GetComponent<CoolHolder>().coolDownComplete)
        {
            transform.position = startPosition;
            trapactive = true;
			sound.time = 0.5f;
			sound.Play();
			looker.GetComponent<CoolHolder>().timeStamp = Time.time + looker.GetComponent<CoolHolder>().universalCooldown;
			durationTimeStamp = Time.time + duration;
			difference = durationTimeStamp - Time.time;
            durationComplete = false;
            //print(trapInput + " Pressed");
        }

        /*if(trapactive && trapType == "Fire")
        {
            ps.Play();
            m_collider.enabled = true;
            if (Time.time >= durationTimeStamp)
            {
                sound.Stop();
                ps.Stop();
                m_collider.enabled = false;
                trapactive = false;
                durationComplete = true;
            }
        }
        else if(fireTrigger == 1 && looker.GetComponent<CoolHolder>().coolDownComplete)
        {
			sound.time = 0.5f;
			sound.Play(0);
			trapactive = true;
            looker.GetComponent<CoolHolder>().timeStamp = Time.time + looker.GetComponent<CoolHolder>().universalCooldown;
            durationTimeStamp = Time.time + duration;
            durationComplete = false;
            print(trapInput + " Pressed");
        }*/
    }

    void FixedUpdate()
    {
        if (trapactive)
        {
            looker.GetComponent<CoolHolder>().coolDownComplete = false;
            if (trapType == "Saw")//pick animation for trap going off or more specific hitboxes
            {
                //print("Activating Saw");
                m_collider.enabled = true;
                anim.SetTrigger("activateSaws");
                trapactive = false;
                durationComplete = true;
            }
            if (trapType == "DropFloor")//pick animation for trap going off or more specific hitboxes
            {
                //print("Activating Drop Floor");
                double firstRow = durationTimeStamp - (difference * 0.9);
                double secondRow = durationTimeStamp - (difference * 0.8);
                double end = durationTimeStamp - (difference * 0.5);


                if (Time.time < firstRow && dropTrapRow == "1")
                {
                    transform.Translate(-transform.forward * moveSpeed * Time.deltaTime, Space.World);
                }
                else if (Time.time > firstRow && Time.time < secondRow && dropTrapRow == "2")
                {
                    transform.Translate(-transform.forward * moveSpeed * Time.deltaTime, Space.World);
                }
                else if (Time.time > secondRow && Time.time < end)
                {
					sound.Stop();
					transform.Translate(transform.forward * (moveSpeed / 3) * Time.deltaTime, Space.World);
                }
                else if (Time.time > end)
                {
                    transform.position = startPosition;
                    trapactive = false;
					sound.Stop();
					durationComplete = true;
                    //print("Done");
				}
            }
            if (trapType == "Needle")//pick animation for trap going off or more specific hitboxes
            {
                m_collider.enabled = true;
                //print("Activating Needle");
                anim.SetTrigger("activateNeedle");
                trapactive = false;
				sound.Stop();
				durationComplete = true;
            }
			if (trapType == "Fire")
			{
				ps.Play();
				m_collider.enabled = true;
				if (Time.time >= durationTimeStamp)
				{
					sound.Stop();
					ps.Stop();
					m_collider.enabled = false;
					trapactive = false;
					durationComplete = true;
				}
			}
		}
        else
        {
            if(trapType == "Saw" && Time.time >= durationTimeStamp)
            {
                m_collider.enabled = false;
            }
            if(trapType == "Needle" && Time.time >= durationTimeStamp)
            {
                m_collider.enabled = false;
            }
            //GetComponent<Collider>().isTrigger = false;
        }
        if (!looker.GetComponent<CoolHolder>().coolDownComplete)
        {
            cooldown();
        }

    }

    void cooldown()
    {
        if (looker.GetComponent<CoolHolder>().timeStamp <= Time.time)
        {
            //print("cooldown");
            looker.GetComponent<CoolHolder>().coolDownComplete = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(0, 1000, 0);
            other.GetComponent<PlayerPickUp>().startRespawn();
            other.GetComponent<PlayerPickUp>().HasObject = false;
        }
    }
}
