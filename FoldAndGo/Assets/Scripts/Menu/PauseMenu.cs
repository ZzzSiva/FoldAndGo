using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    GameManager gameManager;

    public Button pauseButton;
    public Button mainMenuButton;
    public Button selectionButton;
    public Button leaveButton;
    public Button backButton;

    public GameObject pauseMenuUI;
    public GameObject menuIconUI;

    void Awake () {
        gameManager = GameManager.Instance;
        gameManager.OnStateChange += HandleOnStateChange;
    }

    public void HandleOnStateChange ()
    {
        Debug.Log("OnStateChange!");
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
        pauseMenuUI.SetActive(true);
        menuIconUI.SetActive(false);
        //Time.timeScale = 0f;
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        menuIconUI.SetActive(true);
        //Time.timeScale = 1f;
    }


    public void BackMainMenu(){
        gameManager.SetGameState(GameState.MAIN_MENU);
        Debug.Log(gameManager.gameState);
        SceneManager.LoadScene("MainMenu");
    }

    public void OrigamiSelection(){
        gameManager.SetGameState(GameState.PLAYER_SELECTION);
        Debug.Log(gameManager.gameState);
        SceneManager.LoadScene("PlayerSelection");
    }

    public void Quit(){
        Debug.Log("Quit!");
        Application.Quit();
    }
}
