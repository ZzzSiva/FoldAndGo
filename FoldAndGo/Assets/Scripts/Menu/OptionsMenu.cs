using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    GameManager gameManager;

    public Button leaveButton;
    public Button backButton;

    [SerializeField] Slider volumeSlider;

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
        Button backBtn = backButton.GetComponent<Button>();
		backBtn.onClick.AddListener(BackMainMenu);

        Button leaveBtn = leaveButton.GetComponent<Button>();
		leaveBtn.onClick.AddListener(Quit);

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolume();
        }else{
            LoadVolume();
        }
        
    }


    public void ChangeVolume(){
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    private void LoadVolume(){
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void SaveVolume(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void BackMainMenu(){
        gameManager.SetGameState(GameState.MAIN_MENU);
        Debug.Log(gameManager.gameState);
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){
        Debug.Log("Quit!");
        Application.Quit();
    }
}
