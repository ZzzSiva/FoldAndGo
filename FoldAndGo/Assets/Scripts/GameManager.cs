using UnityEngine;
using System.Collections;

// Game States
// for now we are only using these two
public enum GameState { MAIN_MENU, OPTIONS_MENU, PLAYER_SELECTION, GAME, END_MENU }

public delegate void OnStateChangeHandler();

public class GameManager: Object {
    protected GameManager() {}
    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public  GameState gameState { get; private set; }

    public static GameManager Instance{
        get {
            if (GameManager.instance == null){
                GameManager.instance = new GameManager();
                // DontDestroyOnLoad(GameManager.instance);
            }
            return GameManager.instance;
        }
    }

    public void SetGameState(GameState state){
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit(){
        GameManager.instance = null;
    }
}