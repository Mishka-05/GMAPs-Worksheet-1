using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x + b.x, a.y + b.y);
    }

    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x - b.x, a.y - b.y);
    }

    public static HVector2D operator *(HVector2D a, float scalar)
    {
        return new HVector2D(a.x * scalar, a.y * scalar);
    }

    public static HVector2D operator /(HVector2D a, float scalar)
    {
        return new HVector2D(a.x / scalar, a.y / scalar);
    }

    public float Magnitude()
    {
        // Magnitude takes the square root of x^2 + y^2
        // Pythagorean theorem of a^2 + b^2 = c^2, this is to find c
        return (float)Math.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        // We need to get the magnitude again in order to do the normalization
        float magnitude = Magnitude();
        
        // This is to check to ensure that the vector has magnitude
        // Otherwise it would attempt to divide by 0
        if (magnitude != 0)
        {
            // Normalize is to convert the vector's magnitude to a value of 1
            // A normalized vector will still maintain its original direction
            x /= magnitude;
            y /= magnitude;
        }
    }

    public float DotProduct(HVector2D vec)
    {
        return (x * vec.x + y * vec.y);
    }

    public HVector2D Projection(HVector2D b)
    {
        HVector2D proj = b * (DotProduct(b) / b.DotProduct(b));
        return proj;
    }

    public float FindAngle(HVector2D vec)
    {
        return ((float)Mathf.Acos(DotProduct(vec) / (Magnitude() * vec.Magnitude()))) * Mathf.Rad2Deg;
    }

    public Vector2 ToUnityVector2()
    {
        return new Vector2(x, y);
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0);
    }

    // public void Print()
    // {

    // }
}
