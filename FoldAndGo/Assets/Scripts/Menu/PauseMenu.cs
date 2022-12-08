using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Button pauseButton;
    public Button mainMenuButton;
    public Button selectionButton;
    public Button leaveButton;
    public Button backButton;

    public GameObject pauseMenuUI;
    public GameObject menuIconUI;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {
        Debug.Log("OnStateChange : " + state);
    }

    // Start is called before the first frame update
    void Start()
    {
        Button pauseBtn = pauseButton.GetComponent<Button>();
		pauseBtn.onClick.AddListener(Pause);

        Button backBtn = backButton.GetComponent<Button>();
		backBtn.onClick.AddListener(Resume);

        Button mainMenuBtn = mainMenuButton.GetComponent<Button>();
		mainMenuBtn.onClick.AddListener(BackMainMenu);

        Button selectionBtn = selectionButton.GetComponent<Button>();
		selectionBtn.onClick.AddListener(OrigamiSelection);

        Button leaveBtn = leaveButton.GetComponent<Button>();
		leaveBtn.onClick.AddListener(Quit);
    }

    public void Pause(){
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        pauseMenuUI.SetActive(true);
        menuIconUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume(){
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        pauseMenuUI.SetActive(false);
        menuIconUI.SetActive(true);
        Time.timeScale = 1f;
    }


    public void BackMainMenu(){
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        GameManager.Instance.SetGameState(GameState.MAIN_MENU);
        Debug.Log(GameManager.Instance.gameState);
        SceneManager.LoadScene("MainMenu");
    }

    public void OrigamiSelection(){
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        GameManager.Instance.SetGameState(GameState.PLAYER_SELECTION);
        Debug.Log(GameManager.Instance.gameState);
        SceneManager.LoadScene("PlayerSelection");
    }

    public void Quit(){
        FindObjectOfType<AudioManager>().playSound("ExitBtn");
        Debug.Log("Quit!");
        Application.Quit();
    }
}
