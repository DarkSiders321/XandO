using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int[,] gameTab;

    public  Sprite player1;
    public  Sprite player2;

    public  Sprite empty;


    public enum turns {player1, player2};
    public turns turn;

    // Use this for initialization
    void Start () {
        gameTab = new int[3, 3];
        turn = turns.player1;
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void checkClickedPad(int padRow, int padColumn){

        if (gameTab[padRow, padColumn] == 0)
        {
            if (turn == turns.player1)
                gameTab[padRow, padColumn] = 1;
            else if (turn == turns.player2)
                gameTab[padRow, padColumn] = 2;


            checkWinner();
            switchPlayer();
            updateView(padRow, padColumn);
        }
        else
            Debug.Log("Alredy taken");
    }

    public void switchPlayer()
    {
        if (turn == turns.player1)
            turn = turns.player2;
        else if (turn == turns.player2)
            turn = turns.player1;
    }


    public void updateView(int padRow, int padColumn)
    {
        Transform[] allChildren = GameObject.Find("Panel").GetComponentsInChildren<Transform>();

        for(int i = 1; i < allChildren.Length; i++)
        {
            if(allChildren[i].GetComponent<Pad>().row == padRow && allChildren[i].GetComponent<Pad>().column == padColumn)
            {
                if (turn == turns.player1){
                    allChildren[i].GetComponent<Image>().sprite = player1;
                    break;
                }
                else if (turn == turns.player2)
                {
                    allChildren[i].GetComponent<Image>().sprite = player2;
                    break;
                }                
            }
        }
    }

    public void checkWinner()
    {
  
        for (int i = 0; i < 3; i++)
        {
            if (gameTab[i, 0] == 1 && gameTab[i, 1] == 1 && gameTab[i, 2] == 1)
                GameObject.Find("WinText").GetComponent<Text>().text = "Winner is player 1";
            else if (gameTab[i, 0] == 2 && gameTab[i, 1] == 2 && gameTab[i, 2] == 2)
                GameObject.Find("WinText").GetComponent<Text>().text = "Winner is player 2";

            if (gameTab[0, i] == 1 && gameTab[1, i] == 1 && gameTab[2, i] == 1)
                GameObject.Find("WinText").GetComponent<Text>().text = "Winner is player 1";
            else if (gameTab[0, i] == 2 && gameTab[1, i] == 2 && gameTab[2, i] == 2)
                GameObject.Find("WinText").GetComponent<Text>().text = "Winner is player 2";
        }

        if (gameTab[0, 0] == 1 && gameTab[1, 1] == 1 && gameTab[2, 2] == 1 ||
            gameTab[0, 2] == 1 && gameTab[1, 1] == 1 && gameTab[2, 0] == 1)
            GameObject.Find("WinText").GetComponent<Text>().text = "Winner is player 1";
        else if (gameTab[0, 0] == 2 && gameTab[1, 1] == 2 && gameTab[2, 2] == 2 ||
                 gameTab[0, 2] == 2 && gameTab[1, 1] == 2 && gameTab[2, 0] == 2)
            GameObject.Find("WinText").GetComponent<Text>().text = "Winner is player 2";

    }
}
