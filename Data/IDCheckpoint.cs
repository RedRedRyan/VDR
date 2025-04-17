using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class IDCheckpoint : MonoBehaviour
{
    public int checkpointID; // Assign in Inspector (0, 1, 2...)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataLogger dataLogger = FindObjectOfType<DataLogger>();
            if (dataLogger != null)
            {
                dataLogger.OnCheckpointReached(checkpointID);
            }

            // Light up the next checkpoint (optional visual feedback)
            GameObject nextCheckpoint = GameObject.Find($"Checkpoint_{checkpointID + 1}");
            if (nextCheckpoint != null)
            {
                nextCheckpoint.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}