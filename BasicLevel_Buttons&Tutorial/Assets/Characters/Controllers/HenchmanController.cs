using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenchmanController : MonoBehaviour {

    GameObject player;
    static Animator anim;
    public float speed = 20F;
    public float rotationSpeed = 100.0F;
    bool isgrounded = true;
    bool isholding = false;
    Transform itemTransform;
    GameObject holdspot;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player1");
        holdspot = GameObject.Find("HoldSlot");
        /*
        if(player.transform.position.y > 0)
        {
            isgrounded = false;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        // Respawn Player after falling off edge
        if(player.transform.position.y <= -10)
        {
            player.transform.position = new Vector3(0, 22, 0);
        }
   
        if(!isgrounded)
        {
            anim.SetTrigger("Falling");
        }
        else
        {
            anim.SetTrigger("NotFalling");
        }

        if(isholding)
        {
            anim.SetTrigger("Holding");
        }
        else
        {
            anim.SetTrigger("NotHolding");
        }

        if (translation != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
           // anim.SetTrigger("Running");
        }

        if(Input.GetKeyDown(KeyCode.F1))
        {
            anim.SetTrigger("Victory");
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            anim.SetTrigger("Defeat");
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            anim.SetTrigger("Death - Fly Back");
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            anim.SetTrigger("Death - Slow Fall Forward");
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            anim.SetTrigger("Dance - Twerk");
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            anim.SetTrigger("Dance - Shuffle");
        }

        if (Input.GetKeyDown(KeyCode.F7))
        {
            anim.SetTrigger("Falling");
        }


    }

    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Floor")
        {
            isgrounded = true;
        }

        if(theCollision.transform.name == "BoxItem")
        {
            isholding = true;
            itemTransform = theCollision.transform;
            itemTransform.transform.parent = transform;
            itemTransform.transform.position = holdspot.transform.position;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Floor")
        {
            isgrounded = false;
        }
    }
}
