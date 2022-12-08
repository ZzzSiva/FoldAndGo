using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

    public Button playButton;
    public Button optionsButton;
    public Button leaveButton;

    void Awake () {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {
        Debug.Log("OnStateChange : " + state);
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
        GameManager.Instance.SetGameState(GameState.PLAYER_SELECTION);
        Debug.Log(GameManager.Instance.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        FindObjectOfType<AudioManager>().stopSound("MainBackground");
        SceneManager.LoadScene("PlayerSelection");
    }

    public void OptionsMenu(){
        GameManager.Instance.SetGameState(GameState.OPTIONS_MENU);
        Debug.Log(GameManager.Instance.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame() 
    {
        FindObjectOfType<AudioManager>().playSound("ExitBtn");
        Application.Quit();
    }
}
