using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour {

    private PaperMesh6VDog paperMesh;

    [SerializeField]
    public GameObject paper;

    public Button finishButton;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;

        paperMesh = paper.GetComponent<PaperMesh6VDog>();
    }

    void Start () {
		Button finishBtn = finishButton.GetComponent<Button>();
		finishBtn.onClick.AddListener(EndMenu);
        finishBtn.gameObject.SetActive(false);
	}

    private void HandleOnStateChange(GameState state) {
        Debug.Log("OnStateChange : " + state);
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
        GameManager.Instance.SetGameState(GameState.END_MENU);
        Debug.Log(GameManager.Instance.gameState);
        SceneManager.LoadScene("EndMenu");
    }
}
