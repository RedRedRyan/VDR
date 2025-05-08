using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public TMP_Text timerText; // Assign in Inspector
    private float elapsedTime;
    private bool isTimerRunning;

    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        // Convert to minutes:seconds format
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Call this method to start the timer
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    // Optional: Add method to stop/reset timer
    public void StopTimer()
    {
        isTimerRunning = false;
        elapsedTime = 0f;
    }
}