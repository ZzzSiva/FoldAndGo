using UnityEngine;

public class OrigamiStep {
    public int[]   pointsIndex;
    public Vector3 angle;
    public Vector3 pivot;

    public int[]   foldingPointsIndex;
    public int[]   foldingPointsAxeIndex;
    public float   foldingRotation;

    public bool    needPerpendicularCalculation = false;
    public Vector3 perpendicularVector          = new Vector3();

    public Vector3 flipRotation;
    public Vector3 lastRotation;

    public bool    isFlip = false;

    public OrigamiStep() {}
}