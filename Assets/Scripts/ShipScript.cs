using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceLanderController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed for A and D keys
    public float thrustForce = 5f; // Thrust force for W key
    public float crashSpeedThreshold = 10f; // Speed threshold to restart the level

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing!");
        }
    }

    void Update()
    {
        // Handle rotation
        float rotation = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotation = rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation = -rotationSpeed * Time.deltaTime;
        }

        // Apply rotation
        transform.Rotate(0, 0, rotation);

        // Handle thrust
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * thrustForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a "Wall"
        if (collision.collider.CompareTag("Wall"))
        {
            // Calculate the collision impact speed
            float impactSpeed = collision.relativeVelocity.magnitude;

            // Restart the level if the impact speed exceeds the threshold
            if (impactSpeed >= crashSpeedThreshold)
            {
                Debug.Log("Crashed! Restarting level...");
                RestartLevel();
            }
        }


        if (collision.collider.CompareTag("Finish"))
        {
            // Calculate the collision impact speed
            float impactSpeed = collision.relativeVelocity.magnitude;

            // Restart the level if the impact speed exceeds the threshold
            if (impactSpeed >= crashSpeedThreshold + 1)
            {
                Debug.Log("Crashed! Restarting level...");
                RestartLevel();
            }
        }
    }

    void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}