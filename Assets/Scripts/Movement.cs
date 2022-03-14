using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic Schmovement
/// </summary>

public class Movement : MonoBehaviour
{
    Vector3 startPos;
    public Transform transform_hole;
    public float speed = 10f;

    private void Awake()
    {
        startPos = transform_hole.position;
    }

    void Update()
    {
        if (GameManager.IsInputEnabled == true)
        {
            moveHorizontal();
            moveVertical();
        }
        
    }

    private void moveHorizontal()
    {
        Vector3 vec_left = Vector3.zero;
        vec_left.x = Input.GetAxis("Horizontal");
        Vector3 v = new Vector3(vec_left.x, 0.0f, 0.0f) * Time.deltaTime * speed;
        transform_hole.Translate(v, Space.Self);
    }
    
    private void moveVertical()
    {
        Vector3 vec_forward = Vector3.zero;
        vec_forward.z = Input.GetAxis("Vertical");
        Vector3 v = new Vector3(0.0f, 0.0f, vec_forward.z) * Time.deltaTime * speed;
        transform_hole.Translate(v, Space.Self);
    }
}
