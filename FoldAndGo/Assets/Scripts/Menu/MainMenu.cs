using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    GameManager gameManager;
    public Button playButton;
    public Button optionsButton;
    public Button leaveButton;


    void Awake () {
        gameManager = GameManager.Instance;
        //gameManager.OnStateChange += HandleOnStateChange;
    }

    public void HandleOnStateChange ()
    {
        Debug.Log("OnStateChange!");
    }

    void Start () {
		Button playBtn = playButton.GetComponent<Button>();
		playBtn.onClick.AddListener(PlayGame);

        Button optionsBtn = optionsButton.GetComponent<Button>();
		optionsBtn.onClick.AddListener(OptionsMenu);

        Button leaveBtn = leaveButton.GetComponent<Button>();
		leaveBtn.onClick.AddListener(QuitGame);

        FindObjectOfType<AudioManager>().playSound("MainBackground");
	}

    public void PlayGame ()
    {
        gameManager.SetGameState(GameState.PLAYER_SELECTION);
        Debug.Log(gameManager.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        FindObjectOfType<AudioManager>().stopSound("MainBackground");
        SceneManager.LoadScene("PlayerSelection");
    }

    public void OptionsMenu(){
        gameManager.SetGameState(GameState.OPTIONS_MENU);
        Debug.Log(gameManager.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame() 
    {
        FindObjectOfType<AudioManager>().playSound("ExitBtn");
        Application.Quit();
    }
}
