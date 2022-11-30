using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour {

    GameManager gameManager;
    private PaperMesh6VDog paperMesh;

    [SerializeField]
    public GameObject paper;

    void Awake() {
        gameManager = GameManager.Instance;
        gameManager.OnStateChange += HandleOnStateChange;

        paperMesh = paper.GetComponent<PaperMesh6VDog>();
    }

    public void HandleOnStateChange() {
        Debug.Log("OnStateChange!");
    }

    public void PlayNextStep() {
        paperMesh.nextStep();
    }

    public void PlayPreviousStep() {
        paperMesh.previousStep();
    }
}
