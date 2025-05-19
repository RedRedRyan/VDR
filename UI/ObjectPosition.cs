using UnityEngine;
using TMPro;

public class ObjectPositionUI : MonoBehaviour
{
    [Header("Target to Track")]
    public Transform targetObject;  // <-- Drag object here in Inspector

    [Header("UI Text Fields")]
    public TextMeshProUGUI xText;
    public TextMeshProUGUI yText;
    public TextMeshProUGUI zText;

    void Update()
    {
        if (targetObject != null)
        {
            Vector3 pos = targetObject.position;
            xText.text = $"X: {pos.x:F2}";
            yText.text = $"Y: {pos.y:F2}";
            zText.text = $"Z: {pos.z:F2}";
        }
    }
}
