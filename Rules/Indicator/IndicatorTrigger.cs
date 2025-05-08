using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndicatorTrigger : MonoBehaviour
{
    [Header("UI References")]
    public Image leftIndicatorPanel;
    public Image rightIndicatorPanel;
    
    [Header("Trigger Settings")]
    public bool isRightIndicator = true; // Checkbox for right/left
    public float slowmoTimeScale = 0.3f; // How much to slow time (0.3 = 30% speed)
    public float indicatorDuration = 2f; //How long the effect lasts (2 seconds

    private float originalTimeScale;
    private bool isActive;

    void Start()
    {
        // Initialize panels as hidden
        if (leftIndicatorPanel != null) leftIndicatorPanel.gameObject.SetActive(false);
        if (rightIndicatorPanel != null) rightIndicatorPanel.gameObject.SetActive(false);
        originalTimeScale = Time.timeScale;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            StartCoroutine(TriggerIndicator());
        }
    }

    IEnumerator TriggerIndicator()
    {
        isActive = true;
        
        // Slow down time
        Time.timeScale = slowmoTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        // Show correct panel
        if (isRightIndicator)
        {
            if (rightIndicatorPanel != null) rightIndicatorPanel.gameObject.SetActive(true);
        }
        else
        {
            if (leftIndicatorPanel != null) leftIndicatorPanel.gameObject.SetActive(true);
        }

        // Wait for REAL seconds (unaffected by time scale)
        yield return new WaitForSecondsRealtime(indicatorDuration);

        // Reset time
        Time.timeScale = originalTimeScale;
        Time.fixedDeltaTime = 0.02f;

        // Hide panels
        if (leftIndicatorPanel != null) leftIndicatorPanel.gameObject.SetActive(false);
        if (rightIndicatorPanel != null) rightIndicatorPanel.gameObject.SetActive(false);

        isActive = false;
    }

    void OnDestroy()
    {
        // Ensure time reset if destroyed during slowmo
        Time.timeScale = originalTimeScale;
        Time.fixedDeltaTime = 0.02f;
    }
}