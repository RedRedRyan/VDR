using UnityEngine;
using UnityEngine.UI;

public class HideSlowBump : MonoBehaviour
{
    [Header("Slow Down Image")]
    public Image slowDownImage; // Assign the same image as in SlowBump.cs

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the slow down image when player exits
            slowDownImage.gameObject.SetActive(false);
        }
    }
}