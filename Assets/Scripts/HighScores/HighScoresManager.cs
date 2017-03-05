using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour {
    const int NUM_HIGHSCORES = 5;
    Text rankColumn, scoreColumn, nameColumn;

    // Use this for initialization
    void Start () {
        if (!PlayerPrefs.HasKey("HighScore1"))
        {
            for (int i = 1; i <= NUM_HIGHSCORES; i++)
            {
                PlayerPrefs.SetString("HighScore" + i, "0,AAA");
            }
            PlayerPrefs.Save();
        }

        // Fill in the scoreArray
        string[][] scoreArray = new string[NUM_HIGHSCORES][];
        for (int i = 0; i < NUM_HIGHSCORES; i++)
        {
            scoreArray[i] = PlayerPrefs.GetString("HighScore" + (i + 1)).Split(',');
        }

        // Show the score board
        DisplayHighScores(scoreArray);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DisplayHighScores(string[][] scoreArray)
    {
        // Get the Text of each column
        rankColumn = GameObject.Find("RankColumn").GetComponent<Text>();
        scoreColumn = GameObject.Find("ScoreColumn").GetComponent<Text>();
        nameColumn = GameObject.Find("NameColumn").GetComponent<Text>();
        // Initialize each Text with their column header
        rankColumn.text = "Rank\n";
        scoreColumn.text = "Score\n";
        nameColumn.text = "Name\n";
        // Add each row to their respective column
        for (int i = 0; i < NUM_HIGHSCORES; i++)
        {
            rankColumn.text += (i + 1) + "\n";
            scoreColumn.text += scoreArray[i][0] + "\n";
            nameColumn.text += scoreArray[i][1] + "\n";
        }
    }

    public void ClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickReset()
    {
        for (int i = 1; i <= NUM_HIGHSCORES; i++)
        {
            PlayerPrefs.SetString("HighScore" + i, "0,AAA");
        }
        PlayerPrefs.Save();

        // Fill in the scoreArray
        string[][] scoreArray = new string[NUM_HIGHSCORES][];
        for (int i = 0; i < NUM_HIGHSCORES; i++)
        {
            scoreArray[i] = PlayerPrefs.GetString("HighScore" + (i + 1)).Split(',');
        }

        // Show the score board
        DisplayHighScores(scoreArray);
    }
}
