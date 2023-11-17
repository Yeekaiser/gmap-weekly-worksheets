// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    public HMatrix2D mat1 = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
    public HMatrix2D mat2 = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
    public HMatrix2D resultMat;
    public HVector2D vec1;

    void Start()
    {
        mat.SetIdentity();
        mat.Print();
        Question2(mat1, mat2);
    }

    public void Question2(HMatrix2D matrix1, HMatrix2D matrix2)
    {
        resultMat = matrix1 * matrix2;
        resultMat.Print();
    }
}
