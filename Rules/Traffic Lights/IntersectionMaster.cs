using UnityEngine;
using System.Collections;

public class IntersectionMaster : MonoBehaviour
{
    public TrafficLightController[] northSouthLights;
    public TrafficLightController[] eastWestLights;
    public float phaseOffset = 20f; // Total cycle time

    void Start()
    {
        StartCoroutine(IntersectionCycle());
    }

    IEnumerator IntersectionCycle()
    {
        while(true)
        {
            // North-South Green
            SetRoadState(northSouthLights, true);
            SetRoadState(eastWestLights, false);
            yield return new WaitForSeconds(5f);

            // North-South Orange
            SetRoadsToOrange(northSouthLights);
            yield return new WaitForSeconds(5f);

            // East-West Green
            SetRoadState(eastWestLights, true);
            SetRoadState(northSouthLights, false);
            yield return new WaitForSeconds(5f);

            // East-West Orange
            SetRoadsToOrange(eastWestLights);
            yield return new WaitForSeconds(5f);
        }
    }

    void SetRoadState(TrafficLightController[] lights, bool isGreen)
    {
        foreach(var light in lights)
        {
            light.StopAllCoroutines();
            light.UpdateCube(!isGreen);
            light.SetActiveLight(isGreen ? light.greenLight : light.redLight);
        }
    }

    void SetRoadsToOrange(TrafficLightController[] lights)
    {
        foreach(var light in lights)
        {
            light.SetActiveLight(light.orangeLight);
        }
    }
}