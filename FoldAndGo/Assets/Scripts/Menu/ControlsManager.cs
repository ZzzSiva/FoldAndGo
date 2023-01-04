using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Toast ;


public class ControlsManager : MonoBehaviour {

    private PaperMesh6VDog paperMesh;
    private GameObject origamiObject;
    private GameObject fireworks;

    public Button finishButton;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;
        tryGettingPaper();
        tryGettingFireworks();
        fireworks.gameObject.SetActive(false);


    }

    void Start () {
		Button finishBtn = finishButton.GetComponent<Button>();
		finishBtn.onClick.AddListener(EndMenu);
        finishBtn.gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().playSound("GameBackground");
        StartCoroutine(ShowHelpOrigami());
        StartCoroutine(ShowHelpControllers());
	}

    private void HandleOnStateChange(GameState state) {
        Debug.Log("OnStateChange : " + state);
    }

    private void tryGettingFireworks()
    {
        if (fireworks == null)
        {
            fireworks = GameObject.FindGameObjectWithTag("fireworks");

            Debug.Log("XXXXXXXXXXXXXXXXXXX fireworks = " + fireworks);
        }
    }

    private void tryGettingPaper()
    {
        if (paperMesh == null)
        {
            origamiObject = GameObject.FindGameObjectWithTag("origami");

            Debug.Log("XXXXXXXXXXXXXXXXXXX PAPER = " + origamiObject);


            if (origamiObject != null)
            {
                paperMesh = origamiObject.GetComponent<PaperMesh6VDog>();
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

        //tryGettingFireworks();
        //fireworks.gameObject.SetActive(false);

        if (paperMesh != null)
        {
            FindObjectOfType<AudioManager>().playSound("MenuBtn");
            paperMesh.nextStep();
            int current_steps = paperMesh.getCurrentStepIndex();
            int nbOfStpes = paperMesh.getNbOfSteps() - 1;
            Debug.Log("XXXXXXXXXXXXXXXXXXX PAPER = " + current_steps.ToString());
            if(current_steps == nbOfStpes)
            {
                finishButton.gameObject.SetActive(true);

                fireworks.gameObject.SetActive(true);
                fireworks.transform.position = origamiObject.transform.position;
            }
        }
        
    }

    public void PlayPreviousStep() {
        tryGettingPaper();


        //tryGettingFireworks();

        if (paperMesh != null)
        {
            FindObjectOfType<AudioManager>().playSound("MenuBtn");
            paperMesh.previousStep();
            finishButton.gameObject.SetActive(false);
            fireworks.gameObject.SetActive(false);
        }
        
    }

    public void EndMenu(){
        FindObjectOfType<AudioManager>().stopSound("GameBackground");
        FindObjectOfType<AudioManager>().playSound("MenuBtn");
        GameManager.Instance.SetGameState(GameState.END_MENU);
        Debug.Log(GameManager.Instance.gameState);
        SceneManager.LoadScene("EndMenu");
    }

    IEnumerator  ShowHelpOrigami () {
        Toast.Show ("Hold on the screen to display the origami", 4f, ToastColor.Blue, ToastPosition.BottomCenter) ;
        yield return new WaitForSeconds(4f);
   }
   IEnumerator  ShowHelpControllers () {
        Toast.Show ("Use the buttons on your right and left side to change steps", 4f, ToastColor.Blue, ToastPosition.BottomCenter) ;
        yield return new WaitForSeconds(4f);
   }
}
