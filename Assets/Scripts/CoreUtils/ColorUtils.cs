using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUtils
{
    // Color Indices
    public enum ColorIdx { RED, GREEN, BLUE };

    // Color Values
    public static Color red = new Color(1, 0, 0);
    public static Color green = new Color(0, 1, 0);
    public static Color blue = new Color(0, 0, 1);

    public static Color GetColorByIdx(ColorIdx idx)
    {
        if (idx == ColorIdx.RED) return red;
        else if (idx == ColorIdx.GREEN) return green;
        else if (idx == ColorIdx.BLUE) return blue;

        Debug.Log("Color Not Found");
        return new Color(0, 0, 0);
    }

    public static ColorIdx NextColor(ColorIdx current)
    {
        return (ColorIdx)(((int)current + 1) % Enum.GetValues(typeof(ColorIdx)).Length);
    }

    public static bool CompareColor(Color color1, Color color2)
    {
        float errRange = 0.00001f;
        return Mathf.Abs(color1.r - color2.r) < errRange &&
            Mathf.Abs(color1.g - color2.g) < errRange &&
            Mathf.Abs(color1.b - color2.b) < errRange;
    }

    public static bool CompareColor(ColorIdx idx1, ColorIdx idx2)
    {
        return idx1 == idx2;
    }
}
