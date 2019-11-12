using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoolHolder : MonoBehaviour {

	public float universalCooldown = 5f;
    public bool gameOver;
	public bool coolDownComplete;
	public float timeStamp = 0;
    public float timer = 90.0f;
    public float returnTimer = 6f;
    [SerializeField]
    Text timeLeft;
    Image winDisplay;
    [SerializeField]
    Image Ready;
    [SerializeField]
    Image Set;
    [SerializeField]
    Image Go;
    GameObject player1, player2, player3;

    // Use this for initialization
    void Start () {
        winDisplay = GameObject.Find("Super Villain Wins").GetComponent<Image>();
        winDisplay.enabled = false;
        Ready.enabled = true;
        Set.enabled = false;
        Go.enabled = false;
		coolDownComplete = true;
        gameOver = false;
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        player3 = GameObject.Find("Player 3");
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        if(gameOver == false)
        {
            timer -= Time.deltaTime;
            string minutes = ((int)timer / 60).ToString();
            string seconds = (timer % 60).ToString("00");
            if (timer <= 122 && timer > 120)
            {
                startSet();
            }
            if (timer <= 120 && timer > 118)
            {
                startGo();
            }
            if (timer <= 118 && timer > 117)
            {
                disableGo();
            }

            if (timer >= 120)
            {
                timeLeft.text = "2:00";
            }
            else if (minutes == "1" && seconds == "60")
            {
                timeLeft.text = "2:00";
            }
            else if (minutes == "0" && seconds == "60")
            {
                timeLeft.text = "1:00";
            }
            else
            {
                timeLeft.text = minutes + ":" + seconds;
            }

            if (timer < 0)
            {
                gameOver = true;
                timeStamp = Time.time;
                winDisplay.enabled = true;
            }
        }
        else
        {
            timeLeft.text = "0:00";
            if(Time.time >= timeStamp + returnTimer)
            {
                SceneManager.LoadScene("Menu");
            }
        }
	}

	public float getUniCool()
	{
		return universalCooldown;
	}

    void startSet()
    {
        Ready.enabled = false;
        Set.enabled = true;
    }

    void startGo()
    {
        Set.enabled = false;
        Go.enabled = true;
        player1.GetComponent<XboxInput>().movementEnabled = true;
        player2.GetComponent<XboxInput>().movementEnabled = true;
        player3.GetComponent<XboxInput>().movementEnabled = true;
    }

    void disableGo()
    {
        Go.enabled = false;
    }
}
