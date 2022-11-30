using UnityEngine;
using System.Collections;

public class Step {
    public int   number;
    public int[] pointsIndex;
    public Vector3 angle;
    public Vector3 pivot;

    public int[] foldingPointsIndex;
    public int[] foldingPointsAxeIndex;
    public float foldingRotation;

    public bool needPerpendicularCalculation = false;
    public Vector3 perpendicularVector = new Vector3();

    public bool isFlip = false;
    public Vector3 flipRotation;
    public Vector3 lastRotation;

    public Step() {}
}