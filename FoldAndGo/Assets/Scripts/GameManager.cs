using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game States
// for now we are only using these two

public enum GameState {
    MAIN_MENU,
    OPTIONS_MENU,
    PLAYER_SELECTION,
    GAME,
    END_MENU
}

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour {

    public static event Action<GameState> OnGameStateChange;

    public static GameManager Instance;

    public GameState gameState;

    protected GameManager() {}

    private void Awake() {
       if(Instance != null) {
            Destroy(gameObject);
            return;
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetGameState(GameState state){
        this.gameState = state;

        OnGameStateChange?.Invoke(this.gameState);
    }

    public void OnApplicationQuit(){
        GameManager.Instance = null;
    }
}