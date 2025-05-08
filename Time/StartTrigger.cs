using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class StartTrigger : MonoBehaviour
{
    public TimeCounter timer; // Assign the TimeCounter component in Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure your player has "Player" tag
        {
            timer.StartTimer();
            Debug.Log("Timer started!");
        }
    }
}