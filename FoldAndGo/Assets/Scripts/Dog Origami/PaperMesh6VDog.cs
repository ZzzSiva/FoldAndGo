using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PaperMesh6VDog : MonoBehaviour {
    Mesh mesh;
    public Vector3[] vertices;
    int[] triangles;
    List<Step> stepsList = new List<Step>();
    int currentStepIndex = -1;
    int nbOfSteps = 4;
    Step step1;
    Step step2;
    Step step3;
    Step step4;
    Vector3 globalPivotOffset = new Vector3(-0.5f, 0, -0.5f);

    public AnimationCurve curve;

    public float animationDuration = 0.5f;

    const float ROTATION = 180f;

    public bool isStepInAnimation = false;

    public int getCurrentStepIndex()
    {
        return currentStepIndex;
    }

    public int getNbOfSteps()
    {
        return nbOfSteps;
    }

    private void Awake() {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Start() {
        initMeshData();

        initSteps();

        //doFold(step1);
        //doFold(step2);
        //doFold(step3);
        //doFold(step4);

        updateMesh();
    }

    private void Update() {
        // For TESTING : allow live vertex modification int inspector
        //updateMesh();

        if(!isStepInAnimation) {
            if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                if(currentStepIndex >= 0) {
                    /*
                    undoFold(stepsList[currentStepIndex]);
                    updateMesh();
                    currentStepIndex--;
                    */

                    StartCoroutine(doAnimatedFold(stepsList[currentStepIndex], animationDuration, true));
                    currentStepIndex--;
                }
            } else if(Input.GetKeyDown(KeyCode.RightArrow)) {
                if(currentStepIndex < (stepsList.Count - 1)) {
                    if(currentStepIndex >= -1) {
                        currentStepIndex++;
                        StartCoroutine(doAnimatedFold(stepsList[currentStepIndex], animationDuration));
                    }

                    /*
                    currentStepIndex++;
                    doFold(stepsList[currentStepIndex]);
                    updateMesh();
                    */
                }
            }
        }
    }

    private void initMeshData() {
        // Half 6V
        // -------
        // Create an array of vertices
        Vector3[] halfVerticesPart = new Vector3[] {
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
        int[] halfTrianglesPart = new int[] {
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

        // Creatint 2nd half
        // -----------------
        Vector3[] symetricVerticesPart;

        symetricVerticesPart = duplicateVertices(halfVerticesPart);
        symetricVerticesPart = rotateVertices(symetricVerticesPart, 180, Vector3.up);

        vertices = combineVertices(halfVerticesPart, symetricVerticesPart);
        triangles = multiplyTriangles(halfTrianglesPart, 2);
    }

    private void initSteps() {
        step1 = new Step();
        step1.number = 1;
        step1.foldingPointsIndex = new int[] {
            0,  1,  2,  3,  4,  /*5,  6,  7,*/  8,  9, /*10,*/ 11, 12, /*13, 14,*/
            //15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            //30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44,
            /*45, 46,*/ 47, 48, /*49,*/ 50, 51, /*52, 53, 54,*/ 55, 56, 57, 58, 59
        };
        // Order is important beacause it will determine the orientation of rotation
        step1.foldingPointsAxeIndex = new int[] { 14, 44 };
        step1.foldingRotation = ROTATION;

        stepsList.Add(step1);

        step2 = new Step();
        step2.number = 2;
        step2.foldingPointsIndex = new int[] {
            /*0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13,*/ 14,
            15, /*16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44,
            45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step2.foldingPointsAxeIndex = new int[] { 11, 7 };
        step2.foldingRotation = ROTATION;

        stepsList.Add(step2);

        step3 = new Step();
        step3.number = 3;
        step3.foldingPointsIndex = new int[] {
            /*0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14,
            15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
            30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43,*/ 44,
            45, /*46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step3.foldingPointsAxeIndex = new int[] { 43, 42 };
        step3.foldingRotation = ROTATION;

        stepsList.Add(step3);

        step4 = new Step();
        step4.number = 3;
        step4.foldingPointsIndex = new int[] {
            0, /*1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14,
            15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28,*/ 29,
            30, /*31, 32, /*33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44,
            45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58,*/ 59
        };
        // Order is important beacause it will determine the orientation of rotation
        step4.foldingPointsAxeIndex = new int[] { 32, 27 };
        step4.foldingRotation = ROTATION;

        stepsList.Add(step4);
    }

    private void updateMesh() {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    private Vector3[] duplicateVertices(Vector3[] halfPart) {
        Vector3[] duplicatedVertices = new Vector3[halfPart.Length];

        for(int n = 0 ; n < halfPart.Length ; n++) {
            duplicatedVertices[n] = new Vector3(halfPart[n].x, halfPart[n].y, halfPart[n].z);
        }

        return duplicatedVertices;
    }

    private Vector3[] rotateVertices(Vector3[] verticesToRotate, float angle, Vector3 axis) {
        Vector3[] duplicatedAndRotatedVertices = new Vector3[verticesToRotate.Length];

        Quaternion rotation = Quaternion.AngleAxis(angle, axis);

        for(int n = 0 ; n < verticesToRotate.Length ; n++) {
            duplicatedAndRotatedVertices[n] = rotation * verticesToRotate[n];
        }

        return duplicatedAndRotatedVertices;
    }

    private Vector3[] combineVertices(Vector3[] part1, Vector3[] part2) {
        Vector3[] combinedVertices = new Vector3[part1.Length + part2.Length];

        int index = 0;

        for(int n = 0 ; n < part1.Length ; n++) {
            combinedVertices[n] = part1[n];
            index++;
        }

        for(int n = 0 ; n < part2.Length ; n++) {
            combinedVertices[index + n] = part2[n];
        }

        return combinedVertices;
    }

    private int[] multiplyTriangles(int[] triangles, int multiplicator) {
        int[] multipliedTriangles = new int[triangles.Length * multiplicator];

        for(int n = 0 ; n < triangles.Length ; n++) {
            multipliedTriangles[n] = triangles[n];
        }

        for(int n = triangles.Length ; n < multipliedTriangles.Length ; n++) {
            multipliedTriangles[n] = multipliedTriangles[n - 1] + 1;
        }

        return multipliedTriangles;
    }

    private Vector3 calculateFoldingMiddlePoint(int pointIndex1, int pointIndex2) {
        return Vector3.Lerp(vertices[pointIndex1], vertices[pointIndex2], 0.5f);
    }

    private Vector3 calculateAxis(int foldingPointIndex, Vector3 foldingMiddlePoint) {
        return vertices[foldingPointIndex] - foldingMiddlePoint;
    }

    private void doFold(Step step) {
        Vector3 pivot = calculateFoldingMiddlePoint(step.foldingPointsAxeIndex[0], step.foldingPointsAxeIndex[1]);
        Vector3 axis  = calculateAxis(step.foldingPointsAxeIndex[0], pivot);

        for(int i = 0 ; i < step.foldingPointsIndex.Length ; i++) {
            /*
            Vector3 newPosition = Quaternion.AngleAxis(step.foldingRotation, axis) * (vertices[step.foldingPointsIndex[i]] - pivot) + pivot;
            vertices[step.foldingPointsIndex[i]] = new Vector3(newPosition.x, 0, newPosition.z);
            */

            vertices[step.foldingPointsIndex[i]] =
                Quaternion.AngleAxis(step.foldingRotation, axis) * (vertices[step.foldingPointsIndex[i]] - pivot) + pivot;
        }
    }

    IEnumerator doAnimatedFold(Step step, float duration, bool reverse = false) {
        isStepInAnimation = true;

        int revert = (reverse) ? -1 : 1;
        Vector3 pivot = calculateFoldingMiddlePoint(step.foldingPointsAxeIndex[0], step.foldingPointsAxeIndex[1]);
        Vector3 axis  = calculateAxis(step.foldingPointsAxeIndex[0], pivot);

        Quaternion startRotation = transform.rotation;

        float time = 0f;
        float totalRotation = 0f;
        float previousRotation = 0f;

        while(time < duration) {
            totalRotation = step.foldingRotation * curve.Evaluate(time / duration);

            for(int i = 0 ; i < step.foldingPointsIndex.Length ; i++) {
                vertices[step.foldingPointsIndex[i]] =
                    Quaternion.AngleAxis(revert * (totalRotation - previousRotation), axis) * (vertices[step.foldingPointsIndex[i]] - pivot) + pivot;
            }

            previousRotation = totalRotation;

            time += Time.deltaTime;

            updateMesh();

            yield return null;
        }

        float lastRotation = ROTATION - totalRotation;

        for(int i = 0 ; i < step.foldingPointsIndex.Length ; i++) {
            vertices[step.foldingPointsIndex[i]] =
                Quaternion.AngleAxis(revert * lastRotation, axis) * (vertices[step.foldingPointsIndex[i]] - pivot) + pivot;
        }

        updateMesh();

        isStepInAnimation = false;
    }

    private void undoFold(Step step) {
        Vector3 pivot = calculateFoldingMiddlePoint(step.foldingPointsAxeIndex[0], step.foldingPointsAxeIndex[1]);
        Vector3 axis  = calculateAxis(step.foldingPointsAxeIndex[0], pivot);

        for(int i = 0 ; i < step.foldingPointsIndex.Length ; i++) {
            /*
            Vector3 newPosition = Quaternion.AngleAxis(-step.foldingRotation, axis) * (vertices[step.foldingPointsIndex[i]] - pivot) + pivot;
            vertices[step.foldingPointsIndex[i]] = new Vector3(newPosition.x, 0, newPosition.z);
            */

            vertices[step.foldingPointsIndex[i]] =
                Quaternion.AngleAxis(-step.foldingRotation, axis) * (vertices[step.foldingPointsIndex[i]] - pivot) + pivot;
        }
    }

    public void nextStep() {
        Debug.Log("nextStep STEP = " + currentStepIndex);
        Debug.Log("nextStep stepsList.Count = " + stepsList.Count);
        Debug.Log("nextStep isStepInAnimation = " + isStepInAnimation);

        if(currentStepIndex < (stepsList.Count - 1) && !isStepInAnimation) {
            if(currentStepIndex >= -1) {
                currentStepIndex++;
                StartCoroutine(doAnimatedFold(stepsList[currentStepIndex], animationDuration));
            }
        }
    }

    public void previousStep() {
        Debug.Log("previousStep STEP = " + currentStepIndex);
        Debug.Log("nextStep stepsList.Count = " + stepsList.Count);
        Debug.Log("nextStep isStepInAnimation = " + isStepInAnimation);

        if(currentStepIndex >= 0 && !isStepInAnimation) {
            StartCoroutine(doAnimatedFold(stepsList[currentStepIndex], animationDuration, true));
            currentStepIndex--;
        }
    }

    private void OnDrawGizmos() {
        if(mesh == null) {
            return;
        }

        for(int count = 0 ; count < mesh.vertexCount ; count++) {
            var vert = transform.TransformPoint(mesh.vertices[count]);
            var normal = transform.TransformDirection(mesh.normals[count]);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(vert, 0.01f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(vert, vert + normal);
        }
    }
}
