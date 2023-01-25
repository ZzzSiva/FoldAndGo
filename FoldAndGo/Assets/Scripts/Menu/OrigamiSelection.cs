using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyUI.Toast ;


public class OrigamiSelection : MonoBehaviour{

    public Button levelOneButton;
    public Button levelTwoButton;
    public Button levelThreeButton;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange(GameState state) {}

    void Start() {
		Button levelOne   = levelOneButton.GetComponent<Button>();
        Button levelTwo   = levelTwoButton.GetComponent<Button>();
        Button levelThree = levelThreeButton.GetComponent<Button>();

        if(levelOne)   levelOne.onClick.AddListener(playLevelOne);
        if(levelTwo)   levelTwo.onClick.AddListener(playLevelTwo);
        if(levelThree) levelThree.onClick.AddListener(playLevelThree);
	}

    public void playLevelOne() {
        GameManager.Instance.updateGameLevel(GameLevel.LEVEL_1);
    }

    public void playLevelTwo() {
        GameManager.Instance.updateGameLevel(GameLevel.LEVEL_2);
    }

    public void playLevelThree() {
        GameManager.Instance.updateGameLevel(GameLevel.LEVEL_3);
    }

    public void BackGame() {
        GameManager.Instance.updateGameState(GameState.MAIN_MENU);
    }

    public void QuitGame() {
        GameManager.Instance.updateGameState(GameState.QUIT);
    }
}
