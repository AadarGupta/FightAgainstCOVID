using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    private bool gameOver = false;
	
	// Update is called once per frame
	void Update () {

		if(Player_Info.peopleLeft <= 0 && !gameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("RIP");
    }
}
