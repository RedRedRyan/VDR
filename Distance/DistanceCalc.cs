using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceCalc : MonoBehaviour
{
    public Transform startCube; 
    public Transform endCube;
    public Image bgroundImage;  
    public TextMeshProUGUI distanceText;
    private LineRenderer line;    

    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.positionCount = 2; // Critical!
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = new Material(Shader.Find("Unlit/Color")) { color = Color.red };
    }

    void Update()
    {
        if (!startCube || !endCube || !distanceText || !line) return;

        float distance = Vector3.Distance(startCube.position, endCube.position);
        distanceText.text = $"Distance: {distance:F2} meters";
        
        line.SetPosition(0, startCube.position);
        line.SetPosition(1, endCube.position);
    }
}