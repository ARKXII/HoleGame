using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Global Point Values / Boolean
/// </summary>

public class GameManager : MonoBehaviour
{
    public static int redValue = 5;
    public static int yellowValue = 3;
    public static int greenValue = 1;
    public static int WinCondition = 149;           // Hardcoded win condition. Implement better method

    public static bool IsInputEnabled = true;
}
