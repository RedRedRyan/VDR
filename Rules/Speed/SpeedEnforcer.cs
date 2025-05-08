using UnityEngine;
using UnityEngine.UI;

public class SpeedEnforcer : MonoBehaviour
{
    public Transform checkpointA;  
    public Transform checkpointB;  
    public float speedLimit = 50f; 
    public Text speedDisplay;      

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
        }
        else if (other.transform == checkpointB && isTimerRunning)
        {
            float elapsedTime = Time.time - startTime;
            float speedMetersPerSecond = distance / elapsedTime;
            
            // Convert m/s to km/h (1 m/s = 3.6 km/h)
            float speedKmPerHour = speedMetersPerSecond * 3.6f;

            // Update UI
            speedDisplay.text = "Speed: " + speedKmPerHour.ToString("F1") + " km/h";

            // Check speed limit
            if (speedKmPerHour > speedLimit)
            {
                Debug.LogWarning("FAIL! Speed limit exceeded: " + speedKmPerHour.ToString("F1") + " km/h");
                speedDisplay.color = Color.red;
            }
            else
            {
                Debug.Log("PASS! Speed: " + speedKmPerHour.ToString("F1") + " km/h");
                speedDisplay.color = Color.green;
            }

            isTimerRunning = false;
        }
    }
}