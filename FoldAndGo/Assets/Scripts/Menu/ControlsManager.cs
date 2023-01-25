using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Toast ;


public class ControlsManager : MonoBehaviour {

    private OrigamiPaper paperMesh;
    private GameObject   origamiObject;
    private GameObject   fireworks;

    public Button        finishButton;

    public float         toastDuration = 2f;
    public ToastColor    toastColor    = ToastColor.Orange;
    public ToastPosition toastPosition = ToastPosition.BottomCenter;

    void Awake() {
        GameManager.OnGameStateChange += HandleOnStateChange;

        tryGettingPaper();
        tryGettingFireworks();

        fireworks.SetActive(false);

        if(GameManager.Instance) {
            toastDuration = GameManager.Instance.toastDuration;
            toastColor    = GameManager.Instance.toastColor;
            toastPosition = GameManager.Instance.toastPosition;
        }
    }

    void Start() {
		Button finishBtn = finishButton.GetComponent<Button>();

        if(finishBtn) {
            finishBtn.onClick.AddListener(EndMenu);
            finishBtn.gameObject.SetActive(false);
        }

        StartCoroutine(ShowHelpOrigami());
	}

    private void HandleOnStateChange(GameState state) {}

    private void tryGettingFireworks() {
        if(fireworks == null) {
            fireworks = GameObject.FindGameObjectWithTag("Fireworks");
        }
    }

    private void tryGettingPaper() {
        if(paperMesh == null) {
            origamiObject = GameObject.FindGameObjectWithTag("Origami");

            if(origamiObject != null) {
                paperMesh = origamiObject.GetComponent<OrigamiPaper>();
            } else {
                paperMesh = null;
            }
        }
    }

    public void PlayNextStep() {
        tryGettingPaper();

        if(paperMesh != null) {
            FindObjectOfType<AudioManager>().playSound("MenuBtn");
            paperMesh.nextStep();

            int current_steps = paperMesh.getCurrentStepIndex();
            int nbOfStpes     = paperMesh.getNbOfSteps() - 1;

            if(current_steps == nbOfStpes) {
                finishButton.gameObject.SetActive(true);

                fireworks.SetActive(true);
                fireworks.transform.position = origamiObject.transform.position;
            }
        }
    }

    public void PlayPreviousStep() {
        tryGettingPaper();

        if(paperMesh != null) {
            FindObjectOfType<AudioManager>().playSound("MenuBtn");
            paperMesh.previousStep();

            finishButton.gameObject.SetActive(false);
            fireworks.SetActive(false);
        }
        
    }

    public void EndMenu() {
        GameManager.Instance.updateGameState(GameState.END_MENU);
    }

    IEnumerator ShowHelpOrigami() {
        Toast.Show ("Hold on the screen to display the origami", toastDuration, toastColor, toastPosition) ;
        yield return new WaitForSeconds(toastDuration);
        Toast.Show ("Use the buttons on your right and left side to change steps", toastDuration, toastColor, toastPosition) ;
        yield return new WaitForSeconds(toastDuration);
   }
}
