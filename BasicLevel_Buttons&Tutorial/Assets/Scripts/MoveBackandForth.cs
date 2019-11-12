using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour
{
    public string ButtonDown = "AButton1";
    public float moveSpeed = 1f;
    bool trapactive = false;
    bool coolDownComplete;
    Vector3 startPosition;
    public float xMove = 0;
    public float yMove = 0;
    public float zMove = 0;
    public int runThru = 0;
   
    Vector3 mover;
    Vector3 End;
    public float Cooldown = 3;
    float timeStamp = 0;
    void Start()
    {
        startPosition = transform.position;
        coolDownComplete = true;
        transform.position = new Vector3(0, 1000, 0);
        mover = new Vector3(xMove, yMove, zMove);
        End = startPosition + mover;
    }

    void Update()
    {
        if (Input.GetButtonDown(ButtonDown)  && coolDownComplete)
        {
            transform.position = startPosition;
            trapactive = true;
            timeStamp = Time.time + Cooldown;
            print(ButtonDown + "Pressed");
        }
    }

    void FixedUpdate()
    {
        if (trapactive)
        {
            transform.Translate(mover * moveSpeed * Time.deltaTime, Space.World);
            
            if (transform.position == End )
            {
                mover *= -1;
            }
            if (transform.position == startPosition)
            {

                mover *= -1;
                trapactive = false;
                transform.position = new Vector3(0, 1000, 0);
                coolDownComplete = false;
            }
        }
        cooldown();
    }

    void cooldown()
    {
        if (timeStamp <= Time.time)
        {
            coolDownComplete = true;
        }
    }
}
