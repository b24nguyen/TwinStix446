using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    const int NUM_HIGHSCORES = 5;

    Text rankColumn, scoreColumn, nameColumn;
    GameObject player, highScoreBoard, enterNamePanel;
    PlayerHealthManager playerHealthManager;
    GameController gameController;
    Canvas GameOverMenuCanvas;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        highScoreBoard = GameObject.Find("HighScoreBoard");
        enterNamePanel = GameObject.Find("EnterNamePanel");
        // Disable the gameover menu
        GameOverMenuCanvas = GameObject.Find("GameOverMenu").GetComponent<Canvas>();
        GameOverMenuCanvas.enabled = false;
        // Get reference to player health
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthManager = player.GetComponent<PlayerHealthManager>();
    }
	
	// Update is called once per frame
	void Update () {
        // If the player is dead and the game is running
		if (playerHealthManager.health == 0 && Time.timeScale == 1)
        {
            // Pause the game and display the gameover menu
            Time.timeScale = 0;
            GameOverMenuCanvas.enabled = true;
            // Disable rendering the HighScoreBoard and the enter name panel
            highScoreBoard.SetActive(false);
            enterNamePanel.SetActive(false);

            CheckIfHighScore(gameController.score);
        }
	}

    void CheckIfHighScore(int highScore)
    {
        // TODO: move this initialization to a different script
        // so that the highscoreboard scene can use it
        if (!PlayerPrefs.HasKey("HighScore1"))
        {
            for (int i = 1; i <= 5; i++)
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

        // If the highscore is larger than the smallest score on the scoreboard
        if (highScore > System.Int32.Parse(scoreArray[NUM_HIGHSCORES - 1][0]))
        {
            // The user has a highscore, ask for their name
            enterNamePanel.SetActive(true);
        } else
        {
            // Show the score board
            DisplayHighScores(scoreArray);
        }

    }

    void DisplayHighScores(string[][] scoreArray)
    {
        // Render the HighScoreBoard Panel
        highScoreBoard.SetActive(true);
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
        // Restore regular timescale
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickEnterName()
    {
        int insertHS = gameController.score;

        InputField nameInputField = GameObject.Find("NameInputField").GetComponent<InputField>();
        string name = nameInputField.text;

        string[][] scoreArray = new string[NUM_HIGHSCORES][];
        for (int i = 0; i < NUM_HIGHSCORES; i++)
        {
            scoreArray[i] = PlayerPrefs.GetString("HighScore" + (i + 1)).Split(',');
            if (insertHS > System.Int32.Parse(scoreArray[i][0]))
            {
                int tempScore = System.Int32.Parse(scoreArray[i][0]);
                string tempName = scoreArray[i][1];
                scoreArray[i][0] = insertHS.ToString();
                scoreArray[i][1] = name;

                PlayerPrefs.SetString("HighScore" + (i+1), scoreArray[i][0] +"," + scoreArray[i][1]);

                insertHS = tempScore;
                name = tempName;
            }
        }

        // Save new highscores
        PlayerPrefs.Save();
        // Hide the enter name panel
        enterNamePanel.SetActive(false);
        // Show the score board
        DisplayHighScores(scoreArray);
    }
}
