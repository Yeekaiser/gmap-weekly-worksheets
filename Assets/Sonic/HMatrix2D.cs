// Uncomment this whole file.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        Entries = new float[3, 3];
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
            {
                Entries[y, x] = multiArray[y, x];
            }
    }

    public HMatrix2D(float m00, float m01, float m02,
         float m10, float m11, float m12,
         float m20, float m21, float m22)
    {
        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }


    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMat = new HMatrix2D();
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                left.Entries[y, x] += right.Entries[y, x];
        return left;
        //left += right;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMat = new HMatrix2D();
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                left.Entries[y, x] -= right.Entries[y, x];
        return left;
        //left += right;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                left.Entries[y, x] *= scalar;
        return left;
        //return left * scalar;
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y,
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y            
        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

            // and so on for another 7 entries

            /* 
                00 01 02    xx xx 02
                xx xx xx    xx xx 12
                xx xx xx    xx xx 22
                */
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            /* 
                xx xx xx    00 xx xx
                10 11 12    10 xx xx
                xx xx xx    20 xx xx
                */
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],

            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],

            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],



            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],

            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],

            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]


    );
    }

    //public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    //{
    //    float[,] result = new float[3, 3];

    //    for (int y = 0; y < 3; y++)
    //    {
    //        for (int x = 0; x < 3; x++)
    //        {
    //            for (int z = 0; z < 3; z++)
    //            {
    //                result[y, x] += left.Entries[y, x] * right.Entries[z, x];
    //            }
    //        }
    //    }

    //    return new HMatrix2D(result);
    //}


    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.Entries[y, x] != right.Entries[y, x])
                    return false;
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.Entries[y, x] != right.Entries[y, x])
                    return true;
        return false;
    }

    //    public HMatrix2D transpose()
    //    {
    //        return // your code here
    //    }

    //    public float GetDeterminant()
    //    {
    //        return // your code here
    //    }

    public void SetIdentity()
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                Entries[y, x] = (x == y) ? 1 : 0;
                //if (x == y)
                //{
                //    Entries[y, x] = 1;
                //}
                //else
                //{
                //    Entries[y, x] = 0;
                //}
                //(x == y) ? Entries[y, x] = 1 : Entries[y, x] = 0;
    }

    public void SetTranslationMat(float transX, float transY)
    {
        SetIdentity();
        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = Mathf.Sin(-rad);
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
