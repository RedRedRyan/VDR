using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataLogger : MonoBehaviour
{
    private static DataLogger instance;
    private string filePath;
    private string playerName;
    private DateTime sessionStartTime;
    private List<float> journeyTimes = new List<float>();
    private float lastCheckpointTime;

    void Awake()
    {
        // Singleton pattern to prevent duplicates
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeLogger();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeLogger()
    {
        filePath = Path.Combine(Application.persistentDataPath, "PlayerJourneyData.csv");
        
        // Initialize CSV with headers if file doesn't exist
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("PlayerName,SessionStart,CheckpointJourney,JourneyTime(s),TotalTime(s),DateTime");
            }
        }
    }

    public void SetPlayerName(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            playerName = name;
            sessionStartTime = DateTime.Now;
            lastCheckpointTime = Time.timeSinceLevelLoad;
            Debug.Log($"Player name set to: {playerName}");
        }
    }

    public void LogCheckpoint(int checkpointID)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Cannot log checkpoint - player name not set!");
            return;
        }

        float currentTime = Time.timeSinceLevelLoad;
        float journeyTime = currentTime - lastCheckpointTime;
        lastCheckpointTime = currentTime;

        journeyTimes.Add(journeyTime);

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(
                $"{playerName}," +
                $"{sessionStartTime:yyyy-MM-dd HH:mm:ss}," +
                $"Journey {checkpointID}-{checkpointID + 1}," +
                $"{journeyTime:F2}," +
                $"{currentTime:F2}," +
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
            );
        }

        Debug.Log($"Checkpoint {checkpointID} logged. Journey time: {journeyTime:F2}s");
    }

    // Helper method to get the CSV file path
    public string GetDataFilePath()
    {
        return filePath;
    }
}