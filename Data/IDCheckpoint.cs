using UnityEngine;

public class IDCheckpoint : MonoBehaviour
{
    [Tooltip("Assign unique checkpoint ID in Inspector")]
    public int checkpointID;

    [Header("Visual Feedback")]
    [Tooltip("Enable to highlight next checkpoint")]
    public bool enableVisualFeedback = true;
    [Tooltip("Color to highlight next checkpoint")]
    public Color highlightColor = Color.green;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Log checkpoint data
        DataLogger dataLogger = FindObjectOfType<DataLogger>();
        if (dataLogger != null)
        {
            dataLogger.LogCheckpoint(checkpointID);
        }
        else
        {
            Debug.LogWarning("DataLogger not found in scene!");
        }

        // Visual feedback for next checkpoint
        if (enableVisualFeedback)
        {
            HighlightNextCheckpoint();
        }
    }

    private void HighlightNextCheckpoint()
    {
        GameObject nextCheckpoint = GameObject.Find($"Checkpoint_{checkpointID + 1}");
        if (nextCheckpoint != null)
        {
            Renderer renderer = nextCheckpoint.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = highlightColor;
            }
            else
            {
                Debug.LogWarning($"No Renderer found on Checkpoint_{checkpointID + 1}");
            }
        }
    }

    // Optional: Draw gizmo in editor for better visualization
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        Gizmos.DrawIcon(transform.position + Vector3.up, "Checkpoint.png", true);
    }
}