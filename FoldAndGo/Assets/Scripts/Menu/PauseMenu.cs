using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Button     pauseButton;
    public Button     mainMenuButton;
    public Button     selectionButton;
    public Button     leaveButton;
    public Button     backButton;
    public GameObject pauseMenuUI;
    public GameObject menuIconUI;
    public GameObject pauseMenuBackground;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {}

    // Start is called before the first frame update
    void Start() {
        Button pauseBtn     = pauseButton.GetComponent<Button>();
        Button backBtn      = backButton.GetComponent<Button>();
        Button mainMenuBtn  = mainMenuButton.GetComponent<Button>();
        Button selectionBtn = selectionButton.GetComponent<Button>();
        Button leaveBtn     = leaveButton.GetComponent<Button>();

        if(pauseBtn)     pauseBtn.onClick.AddListener(Pause);
        if(backBtn)      backBtn.onClick.AddListener(Resume);
        if(mainMenuBtn)  mainMenuBtn.onClick.AddListener(BackMainMenu);
        if(selectionBtn) selectionBtn.onClick.AddListener(OrigamiSelection);
        if(leaveBtn)     leaveBtn.onClick.AddListener(Quit);
    }

    public void Pause() {
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        pauseMenuUI.SetActive(true);
        pauseMenuBackground.SetActive(true);
        menuIconUI.SetActive(false);
    }

    public void Resume() {
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        pauseMenuUI.SetActive(false);
        pauseMenuBackground.SetActive(false);
        menuIconUI.SetActive(true);
    }

    public void BackMainMenu() {
        GameManager.Instance.updateGameState(GameState.MAIN_MENU);
    }

    public void OrigamiSelection() {
        GameManager.Instance.updateGameState(GameState.ORIGAMI_SELECTION);
    }

    public void Quit() {
        GameManager.Instance.updateGameState(GameState.QUIT);
    }
}
