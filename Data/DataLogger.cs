using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataLogger : MonoBehaviour
{
    private string filePath;
    private StreamWriter writer;
    private string playerName;
    private DateTime startTime;
    private List<float> journeyTimes = new List<float>();
    private int currentCheckpoint = 0;

    void Start()
    {
        // Initialize CSV file (create if it doesn't exist)
        filePath = Application.dataPath + "/PlayerJourneyData.csv";
        if (!File.Exists(filePath))
        {
            writer = new StreamWriter(filePath, true);
            writer.WriteLine("PlayerName,Date,CheckpointJourney,TimeTaken(s)");
            writer.Close();
        }
    }

    // Call this method from a UI input field to set the player name
    public void SetPlayerName(string name)
    {
        playerName = name;
        startTime = DateTime.Now; // Record session start time
    }

    // Call this when a checkpoint is reached
    public void OnCheckpointReached(int checkpointID)
    {
        float journeyTime = Time.timeSinceLevelLoad; // Time since scene start
        journeyTimes.Add(journeyTime);

        // Log data to CSV
        writer = new StreamWriter(filePath, true);
        writer.WriteLine($"{playerName},{DateTime.Now},Journey {checkpointID}-{checkpointID + 1},{journeyTime}");
        writer.Close();

        Debug.Log($"Checkpoint {checkpointID} reached! Time: {journeyTime}s");
    }
}