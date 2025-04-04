using UnityEngine;
using UnityEngine.UI;

public class SpeedEnforcer : MonoBehaviour
{
    public Transform checkpointA;  // Assign in Inspector
    public Transform checkpointB;  // Assign in Inspector
    public float speedLimit = 13.9f; // 50 km/h in m/s (50 / 3.6)
    public Text speedDisplay;      // Assign a UI Text element

    private float startTime;
    private bool isTimerRunning;
    private float distance;

    void Start()
    {
        distance = Vector3.Distance(checkpointA.position, checkpointB.position);
        Debug.Log("Distance between checkpoints: " + distance + " meters");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == checkpointA)
        {
            startTime = Time.time;
            isTimerRunning = true;
            Debug.Log("Timer started at Checkpoint A");
        }
        else if (other.transform == checkpointB && isTimerRunning)
        {
            float elapsedTime = Time.time - startTime;
            float speed = distance / elapsedTime; // Speed = Distance / Time

            // Update UI
            speedDisplay.text = "Speed: " + speed.ToString("F1") + " m/s";

            // Check speed limit
            if (speed > speedLimit)
            {
                Debug.LogWarning("FAIL! Speed limit exceeded: " + speed + " m/s");
                speedDisplay.color = Color.red;
            }
            else
            {
                Debug.Log("PASS! Speed: " + speed + " m/s");
                speedDisplay.color = Color.green;
            }

            isTimerRunning = false;
        }
    }
}