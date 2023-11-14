using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    [SerializeField] bool Qn2;
    private HMatrix2D mat = new HMatrix2D();
    // Start is called before the first frame update
    void Start()
    {
        if (Qn2)
        {
            Question2();
        }
        /*mat.SetIdentity();
        mat.Print();*/
    }
    
    void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(
            6, 3, 2,
            1, 7, 5,
            8, 9, 4);

        HMatrix2D mat2 = new HMatrix2D(
            9, 2, 0,
            4, 3, 0,
            10, 8, 0);

        HVector2D vec1 = new HVector2D(1,1);

        HMatrix2D resultMat = mat1 * mat2;
        resultMat.Print();
    }
}
