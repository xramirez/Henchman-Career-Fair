using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignControllers : MonoBehaviour {
    public int VillianId;
    public int Player1Id;
    public int Player2Id;
    public int Player3Id;
    public GameObject ContSelector;
	// Use this for initialization
	void Start () {
        ContSelector = GameObject.Find("ControllerSelector");
        VillianId = ContSelector.GetComponent<ControllerSelectionMenu>().VillianNum;
        switch(VillianId)
        {
            case 1:
                Player1Id = ContSelector.GetComponent<ControllerSelectionMenu>().player4ControllerNum;
                Player2Id = ContSelector.GetComponent<ControllerSelectionMenu>().player2ControllerNum;
                Player3Id = ContSelector.GetComponent<ControllerSelectionMenu>().player3ControllerNum;
                break;
            case 2:
                Player1Id = ContSelector.GetComponent<ControllerSelectionMenu>().player1ControllerNum;
                Player2Id = ContSelector.GetComponent<ControllerSelectionMenu>().player4ControllerNum;
                Player3Id = ContSelector.GetComponent<ControllerSelectionMenu>().player3ControllerNum;
                break;
            case 3:
                Player1Id = ContSelector.GetComponent<ControllerSelectionMenu>().player4ControllerNum;
                Player2Id = ContSelector.GetComponent<ControllerSelectionMenu>().player2ControllerNum;
                Player3Id = ContSelector.GetComponent<ControllerSelectionMenu>().player4ControllerNum;
                break;
            case 4:
                Player1Id = ContSelector.GetComponent<ControllerSelectionMenu>().player4ControllerNum;
                Player2Id = ContSelector.GetComponent<ControllerSelectionMenu>().player2ControllerNum;
                Player3Id = ContSelector.GetComponent<ControllerSelectionMenu>().player3ControllerNum;
                break;
            case 0:
                Player1Id = ContSelector.GetComponent<ControllerSelectionMenu>().player1ControllerNum;
                Player2Id = ContSelector.GetComponent<ControllerSelectionMenu>().player2ControllerNum;
                Player3Id = ContSelector.GetComponent<ControllerSelectionMenu>().player3ControllerNum;
                break;

        }
        

        GameObject.Find("Player 1").GetComponent<XboxInput>().id = Player1Id;
        GameObject.Find("Player 2").GetComponent<XboxInput>().id = Player2Id;
        GameObject.Find("Player 3").GetComponent<XboxInput>().id = Player3Id;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Player 1").GetComponent<XboxInput>().id = Player1Id;
        GameObject.Find("Player 2").GetComponent<XboxInput>().id = Player2Id;
        GameObject.Find("Player 3").GetComponent<XboxInput>().id = Player3Id;
    }
}
