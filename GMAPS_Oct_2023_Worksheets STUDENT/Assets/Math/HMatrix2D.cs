using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class HMatrix2D : MonoBehaviour
{

    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        SetIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                entries[y, x] = multiArray[y, x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
                    float m10, float m11, float m12,
                    float m20, float m21, float m22)
    {
        entries[0, 0] = m00;
        entries[1,0] = m01;
        entries[2, 0] = m02;
        entries[0, 1] = m10;
        entries[1, 1] = m11;
        entries[2, 1] = m12;
        entries[0, 2] = m20;
        entries[1, 2] = m21;
        entries[2, 2] = m22;
    }
    
    public void SetIdentity()
    {
        /*for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (x == y)
                {
                    entries[y, x] = 1;
                }
                else
                {
                    entries[y, x] = 0;
                }
            }
        }*/

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                entries[y, x] = x == y ? 1 : 0;
            }
        }
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
