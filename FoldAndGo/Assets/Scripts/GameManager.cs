using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyUI.Toast;

// Game States
public enum GameState {
    MAIN_MENU,
    OPTIONS_MENU,
    ORIGAMI_SELECTION,
    GAME,
    END_MENU,
    QUIT
}

// Game Levels
public enum GameLevel {
    LEVEL_1,
    LEVEL_2,
    LEVEL_3
}

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour {

    public static event Action<GameState> OnGameStateChange;

    public static GameManager Instance;

    public GameState gameState;
    public GameLevel gameLevel;

    public float         toastDuration = 2f;
    public ToastColor    toastColor    = ToastColor.Orange;
    public ToastPosition toastPosition = ToastPosition.BottomCenter;

    protected GameManager() {}

    private void Awake() {
       if(Instance != null) {
            Destroy(gameObject);
            return;
        } else {
            if(!PlayerPrefs.HasKey("level1Step")) {
                PlayerPrefs.SetInt("level1Step", -1);
            }

            if(!PlayerPrefs.HasKey("level2Step")) {
                PlayerPrefs.SetInt("level2Step", -1);
            }

            if(!PlayerPrefs.HasKey("level3Step")) {
                PlayerPrefs.SetInt("level3Step", -1);
            }

            if(PlayerPrefs.HasKey("musicVolume")) {
                AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
            } else {
                PlayerPrefs.SetFloat("musicVolume", 1);
                AudioListener.volume = 1;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            loadAROnce();

            if(gameState == GameState.MAIN_MENU) {
                FindObjectOfType<AudioManager>().playSound("MainBackground");
            } else if(gameState == GameState.ORIGAMI_SELECTION) {
                FindObjectOfType<AudioManager>().playSound("SelectionBackground");
            } else if(gameState == GameState.GAME) {
                FindObjectOfType<AudioManager>().playSound("GameBackground");
            } else if(gameState == GameState.END_MENU) {
                FindObjectOfType<AudioManager>().playSound("WinBackground");
            }
        }
    }

    public void updateGameState(GameState newState) {
        gameState = newState;
        applyGameState();
    }

    public void updateGameLevel(GameLevel newLevel) {
        gameLevel = newLevel;

        if(gameLevel == GameLevel.LEVEL_3) {
            Toast.Show("<size=24>Will be available in the next update\n STAY  TUNED !</size>", toastDuration, toastColor, toastPosition);
        } else {
            updateGameState(GameState.GAME);
        }
    }

    private void applyGameState() {
        switch(gameState) {
            case GameState.MAIN_MENU:
                displayMenu();
                break;
            case GameState.OPTIONS_MENU:
                displayOptions();
                break;
            case GameState.ORIGAMI_SELECTION:
                displaySelection();
                break;
            case GameState.GAME:
                displayGame();
                break;
            case GameState.END_MENU:
                displayEnd();
                break;
            case GameState.QUIT:
                quit();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }

        OnGameStateChange?.Invoke(gameState);
    }

    private void displayMenu() {
        FindObjectOfType<AudioManager>().changeBackgroundSound("MainBackground");
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("MainMenu");
    }

    private void displayOptions() {
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("OptionsMenu");
    }

    private void displaySelection() {
        FindObjectOfType<AudioManager>().changeBackgroundSound("SelectionBackground");
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("OrigamiSelection");
    }

    private void displayGame() {
        FindObjectOfType<AudioManager>().changeBackgroundSound("GameBackground");
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("Game");
    }

    private void displayEnd() {
        FindObjectOfType<AudioManager>().changeBackgroundSound("WinBackground");
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("EndMenu");
    }

    private void quit() {
        FindObjectOfType<AudioManager>().playSound("ExitBtn");
        Application.Quit();
    }

    private void loadAROnce() {
        GameObject prefab       = Resources.Load("AR/AR", typeof(GameObject)) as GameObject;
        GameObject gameObjectAR = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);

        DontDestroyOnLoad(gameObjectAR);
    }

    public void SetGameState(GameState state){
        this.gameState = state;

        OnGameStateChange?.Invoke(this.gameState);
    }

    public void OnApplicationQuit(){
        GameManager.Instance = null;
    }
}