using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    GameManager gameManager;
    public Button mainMenuButton;
    public Button playAgainButton;
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
		Button mainMenuBtn = mainMenuButton.GetComponent<Button>();
		mainMenuBtn.onClick.AddListener(BackMainMenu);

        Button playAgainBtn = playAgainButton.GetComponent<Button>();
		playAgainBtn.onClick.AddListener(PlayAgain);

        Button leaveBtn = leaveButton.GetComponent<Button>();
		leaveBtn.onClick.AddListener(Quit);
	}

    public void BackMainMenu(){
        gameManager.SetGameState(GameState.MAIN_MENU);
        Debug.Log(gameManager.gameState);
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain(){
        gameManager.SetGameState(GameState.PLAYER_SELECTION);
        Debug.Log(gameManager.gameState);
        SceneManager.LoadScene("PlayerSelection");
    }

    public void Quit(){
        Debug.Log("Quit!");
        Application.Quit();
    }
}
