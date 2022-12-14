using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour {

    private PaperMesh6VDog paperMesh;

    public Button finishButton;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;
        tryGettingPaper();


    }

    void Start () {
		Button finishBtn = finishButton.GetComponent<Button>();
		finishBtn.onClick.AddListener(EndMenu);
        finishBtn.gameObject.SetActive(false);
	}

    private void HandleOnStateChange(GameState state) {
        Debug.Log("OnStateChange : " + state);
    }

    private void tryGettingPaper()
    {
        if (paperMesh == null)
        {
            GameObject paper = GameObject.FindGameObjectWithTag("origami");

            Debug.Log("XXXXXXXXXXXXXXXXXXX PAPER = " + paper);


            if (paper != null)
            {
                paperMesh = paper.GetComponent<PaperMesh6VDog>();
            }
            else
            {
                paperMesh = null;
            }
            Debug.Log("XXXXXXXXXXXXXXXXXXX PAPER MESH = " + paperMesh);
        }
    }

    public void PlayNextStep() {
        tryGettingPaper();

        if (paperMesh != null)
        {
            FindObjectOfType<AudioManager>().playSound("MenuBtn");
            paperMesh.nextStep();
            finishButton.gameObject.SetActive(true);
        }
        
    }

    public void PlayPreviousStep() {
        tryGettingPaper();

        if (paperMesh != null)
        {
            FindObjectOfType<AudioManager>().playSound("MenuBtn");
            paperMesh.previousStep();
            finishButton.gameObject.SetActive(false);
        }
        
    }

    public void EndMenu(){
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        GameManager.Instance.SetGameState(GameState.END_MENU);
        Debug.Log(GameManager.Instance.gameState);
        SceneManager.LoadScene("EndMenu");
    }
}
