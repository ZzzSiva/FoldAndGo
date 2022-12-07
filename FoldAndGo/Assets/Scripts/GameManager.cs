using UnityEngine;
using System.Collections;

// Game States
// for now we are only using these two
public enum GameState { MAIN_MENU, OPTIONS_MENU, PLAYER_SELECTION, GAME, END_MENU }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance ;
    public event OnStateChangeHandler OnStateChange;
    public  GameState gameState { get; private set; }
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
        OnStateChange();
    }

    public void OnApplicationQuit(){
        GameManager.Instance = null;
    }
}