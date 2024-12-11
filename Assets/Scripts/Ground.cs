using UnityEngine;

public class Ground : MonoBehaviour
{
    void Start()
    {
        GenerateMesh();
    }

    void Update()
    {

    }

    void GenerateMesh()
    {
        // Get the Collider2D component
        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null)
        {
            Debug.LogError("No Collider2D component found!");
            return;
        }

        // Create the mesh from the collider
        Mesh colliderMesh = collider.CreateMesh(true, true);
        if (colliderMesh == null)
        {
            Debug.LogError("Failed to create mesh from collider!");
            return;
        }

        // Adjust mesh vertices to account for the collider's offset
        Vector2 colliderOffset = -transform.position;
        Vector3[] vertices = colliderMesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += (Vector3)colliderOffset; // Add the collider's offset
        }
        colliderMesh.vertices = vertices;

        // Assign the adjusted mesh to the MeshFilter
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("No MeshFilter component found!");
            return;
        }
        meshFilter.mesh = colliderMesh;
    }
}
