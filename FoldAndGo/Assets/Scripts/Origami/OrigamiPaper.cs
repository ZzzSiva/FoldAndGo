using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class OrigamiPaper : MonoBehaviour {
    public Mesh        mesh;
    public Vector3[]   vertices;
    public int[]       triangles;

    public BaseOrigami origamiData;

    public int         currentStepIndex  = -1;
    public bool        isStepInAnimation = false;

    public int getCurrentStepIndex() {
        return currentStepIndex;
    }

    public int getNbOfSteps() {
        return origamiData.stepsList.Count;
    }

    private void Awake() {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Start() {
        initMeshData();
        updateMesh();
    }

    private void Update() {
        // For TESTING : allow live vertex modification in inspector

        if(!isStepInAnimation) {
            if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                if(currentStepIndex >= 0) {
                    StartCoroutine(doAnimatedFold(origamiData.stepsList[currentStepIndex], origamiData.animationDuration, true));
                    currentStepIndex--;
                }
            } else if(Input.GetKeyDown(KeyCode.RightArrow)) {
                if(currentStepIndex < (origamiData.stepsList.Count - 1)) {
                    if(currentStepIndex >= -1) {
                        currentStepIndex++;
                        StartCoroutine(doAnimatedFold(origamiData.stepsList[currentStepIndex], origamiData.animationDuration));
                    }
                }
            }
        }
    }

    private void initMeshData() {
        Vector3[] symetricVerticesPart;

        symetricVerticesPart = duplicateVertices(origamiData.defaultHalfVerticesPart);
        symetricVerticesPart = rotateVertices(symetricVerticesPart, 180, Vector3.up);

        vertices  = combineVertices(origamiData.defaultHalfVerticesPart, symetricVerticesPart);
        triangles = multiplyTriangles(origamiData.defaultHalfTrianglesPart, 2);
    }

    private void updateMesh() {
        mesh.Clear();
        mesh.vertices  = vertices;
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

    private Vector3 calculateAxis(Vector3 foldingPoint, Vector3 foldingMiddlePoint) {
        return foldingPoint - foldingMiddlePoint;
    }

    IEnumerator doAnimatedFold(OrigamiStep step, float duration, bool reverse = false) {
        isStepInAnimation = true;

        int revert = (reverse) ? -1 : 1;

        if(!step.isFlip) {
            Vector3 pivot;
            Vector3 axis;

            if(!step.needPerpendicularCalculation) {
                pivot = calculateFoldingMiddlePoint(step.foldingPointsAxeIndex[0], step.foldingPointsAxeIndex[1]);
                axis = calculateAxis(step.foldingPointsAxeIndex[0], pivot);
            } else {
                pivot = vertices[step.foldingPointsAxeIndex[0]];
                axis = calculateAxis(step.perpendicularVector, pivot);
            }

            float time = 0f;
            float totalRotation = 0f;
            float previousRotation = 0f;

            while(time < duration) {
                totalRotation = step.foldingRotation * origamiData.animationCurve.Evaluate(time / duration);

                for(int i = 0 ; i < step.foldingPointsIndex.Length ; i++) {
                    vertices[step.foldingPointsIndex[i]] =
                        Quaternion.AngleAxis(revert * (totalRotation - previousRotation), axis) * (vertices[step.foldingPointsIndex[i]] - pivot) + pivot;
                }

                previousRotation = totalRotation;

                time += Time.deltaTime;

                updateMesh();

                yield return null;
            }

            float lastRotation = step.foldingRotation - totalRotation;

            for(int i = 0 ; i < step.foldingPointsIndex.Length ; i++) {
                vertices[step.foldingPointsIndex[i]] =
                    Quaternion.AngleAxis(revert * lastRotation, axis) * (vertices[step.foldingPointsIndex[i]] - pivot) + pivot;
            }

            updateMesh();
        } else {
            Quaternion startRotation;
            Quaternion endRotation;

            if(revert < 0) {
                startRotation = transform.rotation;
                endRotation = Quaternion.Euler(step.lastRotation);
            } else {
                startRotation = transform.rotation;
                endRotation = Quaternion.Euler(step.flipRotation) * startRotation;
            }

            for(float t = 0 ; t < duration ; t += Time.deltaTime) {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, t / duration);
                yield return null;
            }

            transform.rotation = endRotation;
        }


        isStepInAnimation = false;
    }

    public void nextStep() {
        if(currentStepIndex < (origamiData.stepsList.Count - 1) && !isStepInAnimation) {
            if(currentStepIndex >= -1) {
                currentStepIndex++;
                StartCoroutine(doAnimatedFold(origamiData.stepsList[currentStepIndex], origamiData.animationDuration));
            }
        }
    }

    public void previousStep() {
        if(currentStepIndex >= 0 && !isStepInAnimation) {
            StartCoroutine(doAnimatedFold(origamiData.stepsList[currentStepIndex], origamiData.animationDuration, true));
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