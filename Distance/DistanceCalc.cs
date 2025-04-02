using UnityEngine;
using UnityEngine.UI;

public class DistanceCalc : MonoBehaviour
{
    public Transform startCube; 
    public Transform endCube;   
    public Text distanceText;
    private LineRenderer line;    

    void Start()
{
    line = gameObject.AddComponent<LineRenderer>();
    line.startWidth = 0.1f;
    line.endWidth = 0.1f;
    line.material = new Material(Shader.Find("Standard")) { color = Color.red };
}
    void Update()
    {
        // Calculate Euclidean distance between the cubes
        float distance = Vector3.Distance(startCube.position, endCube.position);

        // Update the UI Text to display the distance
        distanceText.text = "Distance: " + distance.ToString("F2") + " units";
        line.SetPosition(0, startCube.position);
        line.SetPosition(1, endCube.position);
    }
    




}