using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    public AudioClip menuThemes;
    public AudioClip mainTheme;
    public AudioSource musicPlayer;
    private string currScene;
    private static MusicPlayer instance = null;

    public static MusicPlayer Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        // Persist when switching scenes
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "MainMenu" ||
            SceneManager.GetActiveScene().name == "HighScores")
        {
            currScene = "Menus";
            musicPlayer.clip = menuThemes;
            musicPlayer.Play();
        } else
        {
            currScene = "Game";
            musicPlayer.clip = mainTheme;
            musicPlayer.Play();
        }
        SceneManager.activeSceneChanged += sceneChange; // subscribe
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void sceneChange(Scene previousScene, Scene newScene)
    {
        // I am not using previousScene.name since it was always empty...
        if ( currScene == "Game" )
        {
            // If currScene is game the newScene must be MainMenu
            currScene = "Menus";
            musicPlayer.clip = menuThemes;
            musicPlayer.Play();
        }
        else if ( newScene.name == "Game" )
        {
            // If the newScene is Game then play the mainTheme
            currScene = "Game";
            musicPlayer.clip = mainTheme;
            musicPlayer.Play();
        }
        // All other cases fall under switching from MainMenu <-> PauseMenu
        // In which the right music is already playing
    }
}
