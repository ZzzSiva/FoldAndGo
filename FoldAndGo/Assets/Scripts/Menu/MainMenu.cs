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
        gameManager.OnStateChange += HandleOnStateChange;
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
	}

    public void PlayGame ()
    {
        gameManager.SetGameState(GameState.PLAYER_SELECTION);
        Debug.Log(gameManager.gameState);
        SceneManager.LoadScene("PlayerSelection");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsMenu(){
        gameManager.SetGameState(GameState.OPTIONS_MENU);
        Debug.Log(gameManager.gameState);
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
