using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public Button leaveButton;
    public Button backButton;

    [SerializeField] Slider volumeSlider;

    void Awake () {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {
        Debug.Log("OnStateChange : " + state);
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
        GameManager.Instance.SetGameState(GameState.MAIN_MENU);
        Debug.Log(GameManager.Instance.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){
        Debug.Log("Quit!");
        FindObjectOfType<AudioManager>().playSound("ExitBtn");
        Application.Quit();
    }
}
