using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class HMatrix2D : MonoBehaviour
{

    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        Entries = new float[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[y, x] = multiArray[y, x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
                     float m10, float m11, float m12,
                     float m20, float m21, float m22)
    {
        // First Row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second Row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third Row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }
    
    // This sets the identity of the matrix 
    // 1 0 0
    // 0 1 0
    // 0 0 1
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
                Entries[y, x] = x == y ? 1 : 0;
            }
        }
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x];
            }
        }
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x];
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.Entries[y, x] = left.Entries[y, x] * scalar;
            }
        }
        return result;
    }

    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D(left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * right.h,
                             left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * right.h);
    }

    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 01 02
                10 11 12    10 11 12
                20 21 22    20 21 22
            */
            // First row x first column
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],
            // First row x second column
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],
            // First row x third column
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            // Second row x first column
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            // Second row x second column
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            // Second row x third clumn
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            // Third row x first column
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            // Third row x second column
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            // Third row x third column
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y =0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if(left.Entries[y, x] == right.Entries[y, x])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (left.Entries[y, x] != right.Entries[y, x])
                {
                    return true;
                }
            }
        }
        return false;
    }

    /*public HMatrix2D transpose()
    {
        HMatrix2D transposed = new HMatrix2D();

        for (int y = 0; y < 3; y ++)
        {
            for (int x = 0; x < 3; x++)
            {
                transposed.entries[x, y] = this.entries[y, x];
            }
        }
        return transposed;
    }*/

    // public float GetDeterminant()
    // {
    //    return // your code here
    // }
        
    // This creates a matrix with a translation value
    // This matrix represents a 2D translation transformation
    public void SetTranslationMat(float transX, float transY)
    {
        // This is done by first creating a matrix as an identity matrix
        // 1 0 0
        // 0 1 0
        // 0 0 1
        SetIdentity();

        // Then we set the coordinates of the new translation into the matrix
        // 1   0 transX
        // 0   1 transY
        // 0   0   1
        Entries[0, 2] = transX;
        Entries[1, 2] = transY;

    }

    // This creates a matrix with a rotation value
    // This matrix represents a 2D rotation transformation
    public void SetRotationMat(float rotDeg)    
    {
        // This is done by first creating a matrix as an identity matrix
        // 1 0 0
        // 0 1 0
        // 0 0 1
        SetIdentity();

        // Then we calculate the rotation angle in degrees and convert to radians
        // cos(rad) -sin(rad) 0
        // sin(rad) cos(rad)  0
        //    0        0      1
        float rad = rotDeg * Mathf.Deg2Rad;
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    //    public void SetScalingMat(float scaleX, float scaleY)
    //    {
    //        // your code here
    //    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
