using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Button playButton;
    public Button optionsButton;
    public Button leaveButton;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {}

    void Start() {
		Button playBtn    = playButton.GetComponent<Button>();
        Button optionsBtn = optionsButton.GetComponent<Button>();
        Button leaveBtn   = leaveButton.GetComponent<Button>();

        if(playBtn)    playBtn.onClick.AddListener(PlayGame);
        if(optionsBtn) optionsBtn.onClick.AddListener(OptionsMenu);
        if(leaveBtn)   leaveBtn.onClick.AddListener(QuitGame);
	}

    public void PlayGame() {
        GameManager.Instance.updateGameState(GameState.ORIGAMI_SELECTION);
    }

    public void OptionsMenu() {
        GameManager.Instance.updateGameState(GameState.OPTIONS_MENU);
    }

    public void QuitGame() {
        GameManager.Instance.updateGameState(GameState.QUIT);
    }
}
