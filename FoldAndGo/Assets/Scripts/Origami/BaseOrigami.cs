using UnityEngine;
using System.Collections.Generic;

public class BaseOrigami : ScriptableObject {
    public Vector3[]         vertices;
    public int[]             triangles;

    public List<OrigamiStep> stepsList = new List<OrigamiStep>();

    public Vector3           globalPivotOffset = new Vector3(-0.5f, 0, -0.5f);

    public AnimationCurve    animationCurve;
    public float             animationDuration = 0.5f;

    public Vector3[]         defaultHalfVerticesPart;
    public int[]             defaultHalfTrianglesPart;

    public float             DEFAULT_FOLD_ROTATION = 180f;
}
