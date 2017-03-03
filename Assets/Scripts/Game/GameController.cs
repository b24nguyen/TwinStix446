using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GUIText scoreBoard;
    public int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore(int newScoreVal)
    {
        score += newScoreVal;
        updateScore();
    }
    void updateScore()
    {
        scoreBoard.text = "Score: " + score;
    }
}
