using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSelectionMenu : MonoBehaviour {
    public int player1ControllerNum;
    public int player2ControllerNum;
    public int player3ControllerNum;
    public int player4ControllerNum;
    public int VillianNum;
    public Sprite VillianSprite;
    public Sprite PlayerSprite1;
    public Sprite PlayerSprite2;
    public Sprite PlayerSprite3;
    public Sprite PlayerSprite4;
    int p1Panel;
    int p2Panel;
    int p3Panel;
    int p4Panel;
    public List<int> ControllersAssigned;
    bool A1 = true;
    bool A2 = true;
    bool A3 = true;
    bool A4 = true;

    void playerSelection()
    {
        if (Input.GetButtonDown("AButton1")&& A1)
        {
            A1 = false;
            switch (ControllersAssigned.Count)
            {
                case 0:
                    GameObject.Find("Panel1").GetComponent<Image>().sprite = PlayerSprite1;
                    player1ControllerNum = 1;
                    p1Panel = 1;
                    ControllersAssigned.Add(1);
                    break;
                case 1:
                    GameObject.Find("Panel1").GetComponent<Image>().sprite = PlayerSprite2;
                    player2ControllerNum = 1;
                    p2Panel = 1;
                    ControllersAssigned.Add(1);
                    break;
                case 2:
                    GameObject.Find("Panel1").GetComponent<Image>().sprite = PlayerSprite3;
                    player3ControllerNum = 1;
                    p3Panel = 1;
                    ControllersAssigned.Add(1);
                    break;
                case 3:
                    GameObject.Find("Panel1").GetComponent<Image>().sprite = PlayerSprite4;
                    player4ControllerNum = 1;
                    p4Panel = 1;
                    ControllersAssigned.Add(1);
                    break;
                default:
                    break;

            }
        }
        if (Input.GetButtonDown("AButton2") && A2)
        {
            A2 = false;
            switch (ControllersAssigned.Count)
            {
                case 0:
                    GameObject.Find("Panel2").GetComponent<Image>().sprite = PlayerSprite1;
                    player1ControllerNum = 2;
                    p1Panel = 2;
                    ControllersAssigned.Add(2);
                    break;
                case 1:
                    GameObject.Find("Panel2").GetComponent<Image>().sprite = PlayerSprite2;
                    player2ControllerNum = 2;
                    p2Panel = 2;
                    ControllersAssigned.Add(2);
                    break;
                case 2:
                    GameObject.Find("Panel2").GetComponent<Image>().sprite = PlayerSprite3;
                    player3ControllerNum = 2;
                    p3Panel = 2;
                    ControllersAssigned.Add(2);
                    break;
                case 3:
                    GameObject.Find("Panel2").GetComponent<Image>().sprite = PlayerSprite4;
                    player4ControllerNum = 2;
                    p4Panel = 2;
                    ControllersAssigned.Add(2);
                    break;
                default:
                    break;

            }
        }
        if (Input.GetButtonDown("AButton3") && A3)
        {
            A3 = false;
            switch (ControllersAssigned.Count)
            {
                case 0:
                    GameObject.Find("Panel3").GetComponent<Image>().sprite = PlayerSprite1;
                    player1ControllerNum = 3;
                    p1Panel = 3;
                    ControllersAssigned.Add(3);
                    break;
                case 1:
                    GameObject.Find("Panel3").GetComponent<Image>().sprite = PlayerSprite2;
                    player2ControllerNum = 3;
                    p2Panel = 3;
                    ControllersAssigned.Add(3);
                    break;
                case 2:
                    GameObject.Find("Panel3").GetComponent<Image>().sprite = PlayerSprite3;
                    player3ControllerNum = 3;
                    p3Panel = 3;
                    ControllersAssigned.Add(3);
                    break;
                case 3:
                    GameObject.Find("Panel3").GetComponent<Image>().sprite = PlayerSprite4;
                    player4ControllerNum = 3;
                    p4Panel = 3;
                    ControllersAssigned.Add(3);
                    break;
                default:
                    break;
            }
        }
        if (Input.GetButtonDown("AButton4") && A4)
        {
            A4 = false;
            switch (ControllersAssigned.Count)
            {
                case 0:
                    GameObject.Find("Panel4").GetComponent<Image>().sprite = PlayerSprite1;
                    player1ControllerNum = 4;
                    p1Panel = 4;
                    ControllersAssigned.Add(4);
                    break;
                case 1:
                    GameObject.Find("Panel4").GetComponent<Image>().sprite = PlayerSprite2;
                    player2ControllerNum = 4;
                    p2Panel = 4;
                    ControllersAssigned.Add(4);
                    break;
                case 2:
                    GameObject.Find("Panel4").GetComponent<Image>().sprite = PlayerSprite3;
                    player3ControllerNum = 4;
                    p3Panel = 4;
                    ControllersAssigned.Add(4);
                    break;
                case 3:
                    GameObject.Find("Panel4").GetComponent<Image>().sprite = PlayerSprite4;
                    player4ControllerNum = 4;
                    p4Panel = 4;
                    ControllersAssigned.Add(4);
                    break;
                default:
                    break;
            }
        }
        
    }
    void VillainSelection()
    {
        if (Input.GetButtonDown("BButton1"))
        {
            if(VillianNum != 0 && player1ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite1;
            if (VillianNum != 0 && player2ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite2;
            if (VillianNum != 0 && player3ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite3;
            if (VillianNum != 0 && player4ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite4;
            VillianNum = 1;
                GameObject.Find("Panel1").GetComponent<Image>().sprite = VillianSprite;
        }
        if (Input.GetButtonDown("BButton2"))
        {
            if (VillianNum != 0 && player1ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite1;
            if (VillianNum != 0 && player2ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite2;
            if (VillianNum != 0 && player3ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite3;
            if (VillianNum != 0 && player4ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite4;
            VillianNum = 2;
                GameObject.Find("Panel2").GetComponent<Image>().sprite = VillianSprite;
        }
        if (Input.GetButtonDown("BButton3"))
        {
            if (VillianNum != 0 && player1ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite1;
            if (VillianNum != 0 && player2ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite2;
            if (VillianNum != 0 && player3ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite3;
            if (VillianNum != 0 && player4ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite4;
            VillianNum = 3;
                GameObject.Find("Panel3").GetComponent<Image>().sprite = VillianSprite;
        }
        if (Input.GetButtonDown("BButton4"))

        {
            if (VillianNum != 0 && player1ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite1;
            if (VillianNum != 0 && player2ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite2;
            if (VillianNum != 0 && player3ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite3;
            if (VillianNum != 0 && player4ControllerNum == VillianNum) GameObject.Find("Panel" + VillianNum).GetComponent<Image>().sprite = PlayerSprite4;
            VillianNum = 4;
                GameObject.Find("Panel4").GetComponent<Image>().sprite = VillianSprite;
        }

        
    }
    // Use this for initialization
    void Start () {
        VillianNum = 0;
        ControllersAssigned = new List<int>();
        //DontDestroyOnLoad(this.gameObject);
       
    }
	
	// Update is called once per frame
	void Update () {
        playerSelection();
        VillainSelection();
    }
}
