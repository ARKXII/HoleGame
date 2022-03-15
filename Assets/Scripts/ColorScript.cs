using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to easily change object color and point value.
/// To be used with PropertyDrawer
/// </summary>

public class ColorScript : MonoBehaviour
{
    public Renderer Self;
    public enum ColorType
    {
        Red = 0, 
        Green = 1,
        Blue = 2, 
        Yellow = 3,
    }
    [SerializeField] ColorType colorType;               // Allows dropdown list inside Editor
    private int colorIndex;

    private void Awake()
    {
        colorIndex = (int)colorType;                    // Access current ColorType selection
        // Debug.Log("Color Index is: " + colorIndex);
    }

    public void Start()
    {
        Self = GetComponent<Renderer>();                // Change material color/tag according to selection
        if (colorIndex == 0)
        {
            Self.material = MaterialReference.red;
            transform.gameObject.tag = "Red";
        } else if (colorIndex == 1) {
            Self.material = MaterialReference.green;
            transform.gameObject.tag = "Green";
        } else if (colorIndex == 2) {
            Self.material = MaterialReference.blue;
            transform.gameObject.tag = "Blue";
        } else if (colorIndex == 3) {
            Self.material = MaterialReference.yellow;
            transform.gameObject.tag = "Yellow";
        }
    }


}
