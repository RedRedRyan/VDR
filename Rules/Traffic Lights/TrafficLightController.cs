using UnityEngine;
using System.Collections;
using TMPro;

public class TrafficLightController : MonoBehaviour
{
    [Header("Light Materials")]
    public Material redLight;
    public Material orangeLight;
    public Material greenLight;

    [Header("Light Objects")]
    public Renderer redBulb;
    public Renderer orangeBulb;
    public Renderer greenBulb;

    [Header("Road Cubes")]
    public MeshRenderer stopGoCube;
    public Material redCubeMaterial;
    public Material greenCubeMaterial;
    public TMP_Text cubeText;

    [Header("Timing")]
    public float redDuration = 10f;
    public float orangeDuration = 5f;
    public float greenDuration = 5f;

    private Material originalRed;
    private Material originalOrange;
    private Material originalGreen;
    private IEnumerator currentCycle;

    void Start()
    {
        // Store original materials
        originalRed = redBulb.material;
        originalOrange = orangeBulb.material;
        originalGreen = greenBulb.material;
        
        StartCoroutine(TrafficLightCycle());
    }

    IEnumerator TrafficLightCycle()
    {
        while(true)
        {
            // Red Phase
            SetActiveLight(redLight);
            UpdateCube(true);
            yield return new WaitForSeconds(redDuration);

            // Orange Phase
            SetActiveLight(orangeLight);
            yield return new WaitForSeconds(orangeDuration);

            // Green Phase
            SetActiveLight(greenLight);
            UpdateCube(false);
            yield return new WaitForSeconds(greenDuration);

            // Orange Phase before Red
            SetActiveLight(orangeLight);
            yield return new WaitForSeconds(orangeDuration);
        }
    }

    public void SetActiveLight(Material activeMaterial)
    {
        // Set all bulbs to original materials first
        redBulb.material = originalRed;
        orangeBulb.material = originalOrange;
        greenBulb.material = originalGreen;

        // Activate the current light
        if(activeMaterial == redLight) redBulb.material = redLight;
        else if(activeMaterial == orangeLight) orangeBulb.material = orangeLight;
        else if(activeMaterial == greenLight) greenBulb.material = greenLight;
    }

    public void UpdateCube(bool isRed)
    {
        stopGoCube.material = isRed ? redCubeMaterial : greenCubeMaterial;
        cubeText.text = isRed ? "STOP" : "GO";
    }

    public void ResetCycle()
    {
        if(currentCycle != null) StopCoroutine(currentCycle);
        StartCoroutine(TrafficLightCycle());
    }
}