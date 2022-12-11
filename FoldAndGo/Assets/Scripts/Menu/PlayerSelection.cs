using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerSelection : MonoBehaviour{

    public Button levelOneButton;
    public Button levelTwoButton;
    public Button levelThreeButton;
    public Button continueButton;

    public GameObject popupWindow;

    void Awake () {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {
        Debug.Log("OnStateChange : " + state);
    }

    void Start () {
		Button levelOne = levelOneButton.GetComponent<Button>();
		levelOne.onClick.AddListener(Play);

        Button levelTwo = levelTwoButton.GetComponent<Button>();
		levelTwo.onClick.AddListener(Play);

        Button levelThree = levelThreeButton.GetComponent<Button>();
		levelThree.onClick.AddListener(Popup);

        Button continueBtn = continueButton.GetComponent<Button>();
		continueBtn.onClick.AddListener(PopupClicked);

        FindObjectOfType<AudioManager>().playSound("SelectionBackground");
	}



    public void Play ()
    {
        GameManager.Instance.SetGameState(GameState.GAME);
        Debug.Log(GameManager.Instance.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        FindObjectOfType<AudioManager>().stopSound("SelectionBackground");
        SceneManager.LoadScene("Game");
    }

    public void Popup (){
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        popupWindow.SetActive(true);
    }

    public void PopupClicked (){
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        popupWindow.SetActive(false);
    }

    public void BackGame ()
    {
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        FindObjectOfType<AudioManager>().stopSound("SelectionBackground");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame() 
    {
        FindObjectOfType<AudioManager>().playSound("ExitBtn");
        Application.Quit();
    }
}
