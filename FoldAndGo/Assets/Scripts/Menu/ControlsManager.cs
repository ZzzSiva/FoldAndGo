using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour {

    GameManager gameManager;
    private PaperMesh6VDog paperMesh;
    

    [SerializeField]
    public GameObject paper;

    public Button finishButton;


    void Awake() {
        gameManager = GameManager.Instance;
        gameManager.OnStateChange += HandleOnStateChange;

        paperMesh = paper.GetComponent<PaperMesh6VDog>();
    }

    void Start () {
		Button finishBtn = finishButton.GetComponent<Button>();
		finishBtn.onClick.AddListener(EndMenu);
        finishBtn.gameObject.SetActive(false);
	}

    public void HandleOnStateChange() {
        Debug.Log("OnStateChange!");
    }

    public void PlayNextStep() {
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        paperMesh.nextStep();
        finishButton.gameObject.SetActive(true);
    }

    public void PlayPreviousStep() {
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        paperMesh.previousStep();
        finishButton.gameObject.SetActive(false);
    }

    public void EndMenu(){
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        gameManager.SetGameState(GameState.END_MENU);
        Debug.Log(gameManager.gameState);
        SceneManager.LoadScene("EndMenu");
    }
}
