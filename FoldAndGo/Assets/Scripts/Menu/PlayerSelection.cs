using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyUI.Toast ;


public class PlayerSelection : MonoBehaviour{

    public Button levelOneButton;
    public Button levelTwoButton;
    public Button levelThreeButton;

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
		levelTwo.onClick.AddListener(ShowMessage);

        Button levelThree = levelThreeButton.GetComponent<Button>();
		levelThree.onClick.AddListener(ShowMessage);

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

    public void ShowMessage () {
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        Toast.Show ("<size=24>Will be available in the next update\n STAY  TUNED !</size>", 3f, ToastColor.Blue, ToastPosition.BottomCenter) ;
   }
}
