using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Hole Game Logic
/// </summary>

public class HoleScript : MonoBehaviour
{
    public PolygonCollider2D Hole2DCollider;
    public PolygonCollider2D ground2DCollider;
    public MeshCollider GeneratedMeshCollider;
    public Collider GroundCollider;

    public float initialScale = 0.5f;

    Mesh GeneratedMesh;

    private void Start()
    {
        GameObject[] AllGOs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (var go in AllGOs)
        {
            if (go.layer == LayerMask.NameToLayer("Obstacles"))
            {
                Physics.IgnoreCollision(go.GetComponent<Collider>(),GeneratedMeshCollider, true);
            }
        }
    }

    public IEnumerator BigHole() //Hole grows bigger when eating things
    {
        Vector3 GrowHole = transform.localScale;
        Vector3 StopHole = GrowHole * 2;

        float t = 0;

        while (t <= 0.4f)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(GrowHole, StopHole, t);
            yield return null; 
        }
    }


    // Physics  Optimization
    private void OnTriggerEnter(Collider other)                     //on trigger, wakeup object
    {
        Physics.IgnoreCollision(other, GroundCollider, true);
        Physics.IgnoreCollision(other, GeneratedMeshCollider, false);
    }

    private void OnTriggerExit(Collider other)                      //on trigger exit, object sleep
    {
        Physics.IgnoreCollision(other, GroundCollider, false);
        Physics.IgnoreCollision(other, GeneratedMeshCollider, true);
    }

    // ====================== Hole Logic ========================
    public void FixedUpdate()
    {
        if (transform.hasChanged == true)
        {
            transform.hasChanged = false;
            Hole2DCollider.transform.position = new Vector2(transform.position.x, transform.position.z);    //move hole mesh with cylinder
            Hole2DCollider.transform.localScale = transform.localScale * initialScale;                      //hole size logic
            MakeHole2D();
            Make3DMesh();
        }
    }
     
    private void MakeHole2D()
    {
        Vector2[] PointPositions = Hole2DCollider.GetPath(0);

        for (int i = 0; i < PointPositions.Length; i++)
        {
            PointPositions[i] = Hole2DCollider.transform.TransformPoint(PointPositions[i]);
        }

        ground2DCollider.pathCount = 2;
        ground2DCollider.SetPath(1, PointPositions);
    }

    private void Make3DMesh()
    {
        if (GeneratedMesh != null)
        {
            Destroy(GeneratedMesh);
        }
        GeneratedMesh = ground2DCollider.CreateMesh(true, true);
        GeneratedMeshCollider.sharedMesh = GeneratedMesh;
    }
    // ====================== Hole Logic ========================
}

