using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneSelection : MonoBehaviour
{

    GameManager gameManager;
    public Button levelOneButton;
    public Button levelTwoButton;
    public Button levelThreeButton;


    void Awake () {
        gameManager = GameManager.Instance;
        //gameManager.OnStateChange += HandleOnStateChange;
    }

    public void HandleOnStateChange ()
    {
        Debug.Log("OnStateChange!");
    }

    void Start () {
		Button levelOne = levelOneButton.GetComponent<Button>();
		levelOne.onClick.AddListener(Play);

        Button levelTwo = levelTwoButton.GetComponent<Button>();
		levelTwo.onClick.AddListener(Play);

        Button levelThree = levelThreeButton.GetComponent<Button>();
		levelThree.onClick.AddListener(Play);
        FindObjectOfType<AudioManager>().playSound("SelectionBackground");
	}



    public void Play ()
    {
        gameManager.SetGameState(GameState.GAME);
        Debug.Log(gameManager.gameState);
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        FindObjectOfType<AudioManager>().stopSound("SelectionBackground");
        SceneManager.LoadScene("Game");
    }

    public void BackGame ()
    {
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame() 
    {
        FindObjectOfType<AudioManager>().playSound("ExitBtn");
        Application.Quit();
    }
}
