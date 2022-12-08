using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {

    public Button mainMenuButton;
    public Button playAgainButton;
    public Button leaveButton;

    void Awake () {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {
        Debug.Log("OnStateChange : " + state);
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
        GameManager.Instance.SetGameState(GameState.MAIN_MENU);
        Debug.Log(GameManager.Instance.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain(){
        GameManager.Instance.SetGameState(GameState.PLAYER_SELECTION);
        Debug.Log(GameManager.Instance.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("PlayerSelection");
    }

    public void Quit(){
        Debug.Log("Quit!");
        FindObjectOfType<AudioManager>().playSound("ExitBtn");
        Application.Quit();
    }
}
