using UnityEngine;

[CreateAssetMenu]
public class BoatOrigami : BaseOrigami {
    public void Awake() {
        initDefaultMeshData();
        initSteps();
    }

    private void initDefaultMeshData() {
        // Redifining globalPivotOffset
        globalPivotOffset = new Vector3(-0.5f, 0, -0.707f);

        // Half 6V
        // -------
        // Create an array of vertices
        defaultHalfVerticesPart = new Vector3[] {
            // 1st Quarter
            new Vector3(0f, 0f, 0f) + globalPivotOffset, new Vector3(0f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.207f, 0f, 0f) + globalPivotOffset,
            new Vector3(0.207f, 0f, 0f) + globalPivotOffset, new Vector3(0f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.207f) + globalPivotOffset,
            new Vector3(0.207f, 0f, 0f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.293f, 0f, 0f) + globalPivotOffset,
            new Vector3(0.293f, 0f, 0f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.207f) + globalPivotOffset,
            new Vector3(0.293f, 0f, 0f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.5f, 0f, 0f) + globalPivotOffset,
            new Vector3(0.5f, 0f, 0.207f) + globalPivotOffset, new Vector3(0f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.457f) + globalPivotOffset,
            new Vector3(0.25f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.207f) + globalPivotOffset,
            new Vector3(0.5f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.707f) + globalPivotOffset,
            new Vector3(0.5f, 0f, 0.707f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.707f) + globalPivotOffset,
            new Vector3(0.25f, 0f, 0.707f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.457f) + globalPivotOffset, new Vector3(0f, 0f, 0.707f) + globalPivotOffset,
            new Vector3(0f, 0f, 0.707f) + globalPivotOffset, new Vector3(0.25f, 0f, 0.457f) + globalPivotOffset, new Vector3(0f, 0f, 0.207f) + globalPivotOffset,

            // 2nd Quarter
            new Vector3(0.5f, 0f, 0f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.707f, 0f, 0f) + globalPivotOffset,
            new Vector3(0.707f, 0f, 0f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.207f) + globalPivotOffset,
            new Vector3(0.707f, 0f, 0f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.793f, 0f, 0f) + globalPivotOffset,
            new Vector3(0.793f, 0f, 0f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.207f) + globalPivotOffset, new Vector3(1f, 0f, 0.207f) + globalPivotOffset,
            new Vector3(0.793f, 0f, 0f) + globalPivotOffset, new Vector3(1f, 0f, 0.207f) + globalPivotOffset, new Vector3(1f, 0f, 0f) + globalPivotOffset,
            new Vector3(1f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.457f) + globalPivotOffset,
            new Vector3(0.75f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.457f) + globalPivotOffset,
            new Vector3(0.5f, 0f, 0.707f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.457f) + globalPivotOffset,
            new Vector3(1f, 0f, 0.707f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.707f) + globalPivotOffset,
            new Vector3(0.75f, 0f, 0.707f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.457f) + globalPivotOffset, new Vector3(0.5f, 0f, 0.707f) + globalPivotOffset,
            new Vector3(1f, 0f, 0.207f) + globalPivotOffset, new Vector3(0.75f, 0f, 0.457f) + globalPivotOffset, new Vector3(1f, 0f, 0.707f) + globalPivotOffset,
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
            30, 31, 32,

            33, 34, 35,
            36, 37, 38,
            39, 40, 41,
            42, 43, 44,
            45, 46, 47,
            48, 49, 50,
            51, 52, 53,
            54, 55, 56,
            57, 58, 59,
            60, 61, 62,
            63, 64, 65,
        };
    }

    private void initSteps() {
        OrigamiStep step1 = new OrigamiStep();
        step1.foldingPointsIndex = new int[] {
             0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, /*23,
            24,*/ 25, /*26, 27,*/ 28, /*29, 30,*/ 31, 32,

            33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            49, 50, 51, 52, 53, /*54,*/ 55, 56,
            /*57,*/ 58, /*59, 60,*/ 61, /*62,*/ 63, 64, /*65,*/

            /*
            66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,
            
            99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,
            */
        };
        // Order is important beacause it will determine the orientation of rotation
        step1.foldingPointsAxeIndex = new int[] { 65, 30 };
        step1.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step1);

        OrigamiStep step2 = new OrigamiStep();
        step2.foldingPointsIndex = new int[] {
            /* 0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25,*/ 26, 27, /*28,*/ 29, 30, /*31, 32,*/

            ///*33, 34, 35, 36, 37, 38, 39, 40,
            //41, 42, 43, 44, 45, 46, 47, 48,
            //49, 50, 51, 52, 53, 54, 55, 56,*/
            //57, /*58,*/ 59, 60, /*61, 62, 63, 64,*/ 65,
            //
            ///*66, 67, 68, 69, 70, 71, 72, 73,
            //74, 75, 76, 77, 78, 79, 80, 81,
            //82, 83, 84, 85, 86, 87, 88, 89,
            //90, 91,*/ 92, 93, /*94,*/ 95, 96, /*97, 98,*/
            
            /*99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,*/
            123, /*124,*/ 125, 126, /*127, 128, 129, 130,*/ 131,
        };
        // Order is important beacause it will determine the orientation of rotation
        step2.foldingPointsAxeIndex = new int[] { 23, 16 };
        step2.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step2);

        OrigamiStep step3 = new OrigamiStep();
        step3.foldingPointsIndex = new int[] {
            ///* 0,  1,  2,  3,  4,  5,  6,  7,
            // 8,  9, 10, 11, 12, 13, 14, 15,
            //16, 17, 18, 19, 20, 21, 22, 23,
            //24, 25,*/ 26, 27, /*28,*/ 29, 30, /*31, 32,*/

            /*33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            49, 50, 51, 52, 53, 54, 55, 56,*/
            57, /*58,*/ 59, 60, /*61, 62, 63, 64,*/ 65,
            
            /*66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91,*/ 92, 93, /*94,*/ 95, 96, /*97, 98,*/
            
            ///*99, 100, 101, 102, 103, 104, 105, 106,
            //107, 108, 109, 110, 111, 112, 113, 114,
            //115, 116, 117, 118, 119, 120, 121, 122,*/
            //123, /*124,*/ 125, 126, /*127, 128, 129, 130,*/ 131,
        };
        // Order is important beacause it will determine the orientation of rotation
        step3.foldingPointsAxeIndex = new int[] { 82, 89 };
        step3.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step3);

        OrigamiStep step4 = new OrigamiStep();
        step4.foldingPointsIndex = new int[] {
             0,  /*1,*/  2,  3,  /*4,  5,*/  6,  /*7,*/
             8,  9, /*10, 11,*/ 12, /*13,*/ 14, /*15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25, 26, 27, 28, 29, 30, 31, 32,*/

            33, /*34,*/ 35, 36, /*37, 38,*/ 39, /*40,*/
            41, 42, /*43, 44,*/ 45, /*46,*/ 47, /*48,
            49, 50, 51, 52, 53, 54, 55, 56,
            57, 58, 59, 60, 61, 62, 63, 64, 65,*/

            /*66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,

            99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step4.foldingPointsAxeIndex = new int[] { 1, 63 };
        step4.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step4);

        OrigamiStep step5 = new OrigamiStep();
        step5.isFlip = true;
        step5.lastRotation = new Vector3(0f, 0f, 0f);
        step5.flipRotation = new Vector3(0f, 270f, 180f);

        stepsList.Add(step5);

        OrigamiStep step6 = new OrigamiStep();
        step6.foldingPointsIndex = new int[] {
             0,  /*1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25, 26, 27, 28, 29, 30, 31, 32,

            33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            49, 50, 51, 52, 53, 54, 55, 56,
            57, 58, 59, 60, 61, 62, 63, 64, 65,

            66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,

            99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step6.foldingPointsAxeIndex = new int[] { 1, 2 };
        step6.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step6);

        OrigamiStep step7 = new OrigamiStep();
        step7.foldingPointsIndex = new int[] {
             /*0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25, 26, 27, 28, 29, 30, 31, 32,

            33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46,*/ 47, /*48,
            49, 50, 51, 52, 53, 54, 55, 56,
            57, 58, 59, 60, 61, 62, 63, 64, 65,

            66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,

            99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step7.foldingPointsAxeIndex = new int[] { 45, 46 };
        step7.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step7);

        OrigamiStep step8 = new OrigamiStep();
        step8.foldingPointsIndex = new int[] {
             /*0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25, 26, 27, 28, 29, 30, 31, 32,

            33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            49, 50, 51, 52, 53, 54, 55, 56,
            57, 58, 59, 60, 61, 62, 63, 64, 65,*/

            66, /*67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,

            99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step8.foldingPointsAxeIndex = new int[] { 67, 68 };
        step8.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step8);

        OrigamiStep step9 = new OrigamiStep();
        step9.foldingPointsIndex = new int[] {
             /*0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25, 26, 27, 28, 29, 30, 31, 32,

            33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            49, 50, 51, 52, 53, 54, 55, 56,
            57, 58, 59, 60, 61, 62, 63, 64, 65,

            66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,

            99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112,*/ 113, /*114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step9.foldingPointsAxeIndex = new int[] { 111, 112 };
        step9.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step9);

        OrigamiStep step10 = new OrigamiStep();
        step10.foldingPointsIndex = new int[] {
             /*0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25, 26, 27, 28, 29, 30, 31, 32,

            33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            49, 50, 51, 52, 53, 54, 55, 56,
            57, 58, 59, 60, 61, 62, 63, 64, 65,

            66, 67,*/ 68, 69, /*70, 71,*/ 72, /*73,*/
            74, 75, /*76, 77,*/ 78, /*79,*/ 80, /*81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,*/

            99, /*100,*/ 101, 102, /*103, 104,*/ 105, /*106,*/
            107, 108, /*109, 110,*/ 111, /*112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step10.foldingPointsAxeIndex = new int[] { 67, 110 };
        step10.foldingRotation = DEFAULT_FOLD_ROTATION;

        stepsList.Add(step10);

        OrigamiStep step11 = new OrigamiStep();
        step11.foldingPointsIndex = new int[] {
             0,  /*1,  2,  3,  4,*/  5,  /*6,*/  7,
             8,  9, 10, 11, /*12,*/ 13, 14, 15,
            /*16, 17, 18,*/ 19, 20, 21, /*22, 23,
            24, 25,*/ 26, 27, /*28,*/ 29, 30, /*31, 32,*/

            33, 34, 35, 36, 37, 38, 39, 40,
            /*41, 42,*/ 43, /*44, 45, 46,*/ 47, /*48,*/
            49, /*50, 51,*/ 52, 53, /*54, 55,*/ 56,
            57, /*58,*/ 59, 60, /*61, 62, 63, 64,*/ 65,

            /*66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,

            99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step11.foldingPointsAxeIndex = new int[] { 23 };
        step11.needPerpendicularCalculation = true;
        step11.perpendicularVector = new Vector3(0.5f, 0f, 0f);
        step11.foldingRotation = 45f;

        // NOT FINISHED : Need combination with other Steps (Not yet done)
        //stepsList.Add(step11);

        OrigamiStep step12 = new OrigamiStep();
        step12.foldingPointsIndex = new int[] {
             /*0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25, 26, 27, 28, 29, 30, 31, 32,

            33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            49, 50, 51, 52, 53, 54, 55, 56,
            57, 58, 59, 60, 61, 62, 63, 64, 65,*/

            66, /*67, 68, 69, 70,*/ 71, /*72,*/ 73,
            74, 75, 76, 77, /*78,*/ 79, 80, 81,
            /*82, 83, 84,*/ 85, 86, 87, /*88, 89,
            90, 91,*/ 92, 93, /*94,*/ 95, 96, /*97, 98,*/

            99, 100, 101, 102, 103, 104, 105, 106,
            /*107, 108,*/ 109, /*110, 111, 112,*/ 113, /*114,*/
            115, /*116, 117,*/ 118, 119, /*120, 121,*/ 122,
            123, /*124,*/ 125, 126, /*127, 128, 129, 130,*/ 131,
        };
        // Order is important beacause it will determine the orientation of rotation
        step12.foldingPointsAxeIndex = new int[] { 23 };
        step12.needPerpendicularCalculation = true;
        step12.perpendicularVector = new Vector3(-0.5f, 0f, 0f);
        step12.foldingRotation = 45f;

        // NOT FINISHED : Need combination with other Steps (Not yet done)
        //stepsList.Add(step12);

        OrigamiStep step13 = new OrigamiStep();
        step13.foldingPointsIndex = new int[] {
            0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, /*11,*/ 12, /*13, 14, 15,*/
            16, 17, 18, /*19, 20, 21,*/ 22, /*23,
            24,*/ 25, /*26, 27,*/ 28, /*29, 30,*/ 31, 32,

            /*33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            49, 50, 51, 52, 53, 54, 55, 56,
            57, 58, 59, 60, 61, 62, 63, 64, 65,

            66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, 77, 78, 79, 80, 81,
            82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 93, 94, 95, 96, 97, 98,

            /*99, 100,*/ 101, 102, /*103,*/ 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            /*115,*/ 116, 117, /*118, 119, 120,*/ 121, /*122,
            123,*/ 124, /*125, 126,*/ 127, /*128,*/ 129, 130, /*131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step13.foldingPointsAxeIndex = new int[] { 23 };
        step13.needPerpendicularCalculation = true;
        step13.perpendicularVector = new Vector3(0f, 0.5f, 0f);
        step13.foldingRotation = 45f;

        // NOT FINISHED : Need combination with other Steps (Not yet done)
        //stepsList.Add(step13);

        OrigamiStep step14 = new OrigamiStep();
        step14.foldingPointsIndex = new int[] {
             /*0,  1,  2,  3,  4,  5,  6,  7,
             8,  9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23,
            24, 25, 26, 27, 28, 29, 30, 31, 32,

            /*33, 34,*/ 35, 36, /*37,*/ 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48,
            /*49,*/ 50, 51, /*52, 53, 54,*/ 55, /*56,
            57,*/ 58, /*59, 60,*/ 61, /*62,*/ 63, 64, /*65,*/

            66, 67, 68, 69, 70, 71, 72, 73,
            74, 75, 76, /*77,*/ 78, /*79, 80, 81,*/
            82, 83, 84, /*85, 86, 87,*/ 88, /*89,
            90,*/ 91, /*92, 93,*/ 94, /*95, 96,*/ 97, 98,

            /*99, 100, 101, 102, 103, 104, 105, 106,
            107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122,
            123, 124, 125, 126, 127, 128, 129, 130, 131,*/
        };
        // Order is important beacause it will determine the orientation of rotation
        step14.foldingPointsAxeIndex = new int[] { 23 };
        step14.needPerpendicularCalculation = true;
        step14.perpendicularVector = new Vector3(0f, -0.5f, 0f);
        step14.foldingRotation = 45f;

        // NOT FINISHED : Need combination with other Steps (Not yet done)
        //stepsList.Add(step14);
    }
}
