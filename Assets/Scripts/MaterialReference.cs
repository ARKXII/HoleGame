using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Global Material Reference
/// </summary>

public class MaterialReference : MonoBehaviour
{
    public static Material red = Resources.Load("Red", typeof(Material)) as Material;
    public static Material blue = Resources.Load("Blue", typeof(Material)) as Material;
    public static Material yellow = Resources.Load("Yellow", typeof(Material)) as Material;
    public static Material green = Resources.Load("Green", typeof(Material)) as Material;
}
