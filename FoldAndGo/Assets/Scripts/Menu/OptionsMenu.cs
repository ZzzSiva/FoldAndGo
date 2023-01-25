using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public Button leaveButton;
    public Button backButton;

    [SerializeField] Slider volumeSlider;

    void Awake () {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {}

    // Start is called before the first frame update
    void Start() {
        Button backBtn  = backButton.GetComponent<Button>();
        Button leaveBtn = leaveButton.GetComponent<Button>();

        if(backBtn)  backBtn.onClick.AddListener(BackMainMenu);
        if(leaveBtn) leaveBtn.onClick.AddListener(Quit);

        LoadVolume();
    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    private void LoadVolume() {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void SaveVolume() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void BackMainMenu() {
        GameManager.Instance.updateGameState(GameState.MAIN_MENU);
    }

    public void Quit() {
        GameManager.Instance.updateGameState(GameState.QUIT);

    }
}
