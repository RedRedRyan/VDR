using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlowBump : MonoBehaviour
{
    [Header("Slow Down Image")]
    public Image slowDownImage; // Reference to the UI image to show


    void Start()
    {
    slowDownImage.gameObject.SetActive(false); // Hide the image at the start
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the slow down image
            slowDownImage.gameObject.SetActive(true);
        }
    }
}