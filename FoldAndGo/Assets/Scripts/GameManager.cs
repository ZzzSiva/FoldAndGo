using UnityEngine;
using System.Collections;

// Game States
// for now we are only using these two
public enum GameState { MAIN_MENU, OPTIONS_MENU, PLAYER_SELECTION, GAME, END_MENU }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour {
    
    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public  GameState gameState { get; private set; }
    protected GameManager() {
        instance = this;
    }

    public static GameManager Instance{
        get {
            if(instance != null) {
                Destroy(gameObject);
                return;
            } else {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    // private void Awake() {
    //     if(instance != null) {
    //         Destroy(gameObject);
    //         return;
    //     } else {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    public void SetGameState(GameState state){
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit(){
        GameManager.instance = null;
    }
}