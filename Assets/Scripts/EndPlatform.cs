using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPlatform : MonoBehaviour
{
    public string nextScene; // The name of the next scene to load
    public float stayDuration = 3f; // Time the ship must stay on the platform to change the scene

    private float stayTimer = 0f; // Tracks how long the ship has stayed on the platform
    private bool isShipOnPlatform = false; // Tracks if the ship is on the platform

    void Update()
    {
        if (isShipOnPlatform)
        {
            stayTimer += Time.deltaTime;

            if (stayTimer >= stayDuration)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
        else
        {
            // Reset the timer if the ship leaves the platform
            stayTimer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isShipOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isShipOnPlatform = false;
        }
    }
}