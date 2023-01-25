using UnityEngine;

[CreateAssetMenu]
public class DogOrigami : BaseOrigami {
    public void Awake() {
        initDefaultMeshData();
        initSteps();
    }

    private void initDefaultMeshData() {
        // Half 6V
        // -------
        // Create an array of vertices
        defaultHalfVerticesPart = new Vector3[] {
            new Vector3(0f, 0f, 0f) + globalPivotOffset, new Vector3(0.11071f, 0f, 0.11071f) + globalPivotOffset, new Vector3(0.22142f, 0f, 0f) + globalPivotOffset,
            new Vector3(0.22142f, 0f, 0f) + globalPivotOffset, new Vector3(0.11071f, 0f, 0.11071f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.5f) + globalPivotOffset,
            new Vector3(0.5f, 0f, 0.5f) + globalPivotOffset, new Vector3(0.55238f, 0f, 0.44761f) + globalPivotOffset, new Vector3(0.22142f, 0f, 0f) + globalPivotOffset,
            new Vector3(0.22142f, 0f, 0f) + globalPivotOffset, new Vector3(0.55238f, 0f, 0.44761f) + globalPivotOffset, new Vector3(0.66428f, 0f, 0f) + globalPivotOffset,
            new Vector3(0.66428f, 0f, 0f) + globalPivotOffset, new Vector3(0.55238f, 0f, 0.44761f) + globalPivotOffset, new Vector3(1f, 0f, 0f) + globalPivotOffset,

            new Vector3(1f, 0f, 0f) + globalPivotOffset, new Vector3(0.55238f, 0f, 0.44761f) + globalPivotOffset, new Vector3(1f, 0f, 0.33572f) + globalPivotOffset,
            new Vector3(1f, 0f, 0.33572f) + globalPivotOffset, new Vector3(0.55238f, 0f, 0.44761f) + globalPivotOffset, new Vector3(1f, 0f, 0.77858f) + globalPivotOffset,
            new Vector3(1f, 0f, 0.77858f) + globalPivotOffset, new Vector3(0.55238f, 0f, 0.44761f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.5f) + globalPivotOffset,
            new Vector3(0.5f, 0f, 0.5f) + globalPivotOffset, new Vector3(0.88929f, 0f, 0.88929f) + globalPivotOffset, new Vector3(1f, 0f, 0.77858f) + globalPivotOffset,
            new Vector3(1f, 0f, 0.77858f) + globalPivotOffset, new Vector3(0.88929f, 0f, 0.88929f) + globalPivotOffset, new Vector3(1f, 0f, 1f) + globalPivotOffset,
        };

        // Create an array of integers
        defaultHalfTrianglesPart = new int[] {
            0, 1, 2,
            3, 4, 5,
            6, 7, 8,
            9, 10, 11,
            12, 13, 14,

            15, 16, 17,
            18, 19, 20,
            21, 22, 23,
            24, 25, 26,
            27, 28, 29,
        };
    }

    private void initSteps() {
        OrigamiStep step1 = new OrigamiStep();
        step1.foldingPointsIndex = new int[] {
            0,  1,  2,  3,  4,  /*5,  6,  7,*/  8,  9, /*10,*/ 11, 12, /*13, 14,*/
            //15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            //30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44,
            /*45, 46,*/ 47, 48, /*49,*/ 50, 51, /*52, 53, 54,*/ 55, 56, 57, 58, 59
        };
        // Order is important beacause it will determine the orientation of rotation
        step1.foldingPointsAxeIndex = new int[] { 14, 44 };
        step1.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step1);

        OrigamiStep step2 = new OrigamiStep();
        step2.foldingPointsIndex = new int[] {
            /*0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13,*/ 14,
            15, /*16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44,
            45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step2.foldingPointsAxeIndex = new int[] { 11, 7 };
        step2.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step2);

        OrigamiStep step3 = new OrigamiStep();
        step3.foldingPointsIndex = new int[] {
            /*0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14,
            15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43,*/ 44,
            45, /*46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step3.foldingPointsAxeIndex = new int[] { 43, 42 };
        step3.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step3);

        OrigamiStep step4 = new OrigamiStep();
        step4.foldingPointsIndex = new int[] {
            0, /*1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14,
            15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28,*/ 29,
            30, /*31, 32, /*33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44,
            45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58,*/ 59
        };
        // Order is important beacause it will determine the orientation of rotation
        step4.foldingPointsAxeIndex = new int[] { 32, 27 };
        step4.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step4);
    }
}
