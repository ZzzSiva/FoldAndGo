using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {

    public Button mainMenuButton;
    public Button playAgainButton;
    public Button leaveButton;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {}

    void Start() {
		Button mainMenuBtn  = mainMenuButton.GetComponent<Button>();
        Button playAgainBtn = playAgainButton.GetComponent<Button>();
        Button leaveBtn     = leaveButton.GetComponent<Button>();

        if(mainMenuBtn)  mainMenuBtn.onClick.AddListener(BackMainMenu);
        if(playAgainBtn) playAgainBtn.onClick.AddListener(PlayAgain);
        if(leaveBtn)     leaveBtn.onClick.AddListener(Quit);
	}

    public void BackMainMenu() {
        GameManager.Instance.updateGameState(GameState.MAIN_MENU);
    }

    public void PlayAgain() {
        GameManager.Instance.updateGameState(GameState.ORIGAMI_SELECTION);
    }

    public void Quit() {
        GameManager.Instance.updateGameState(GameState.QUIT);
    }
}
