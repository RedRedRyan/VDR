using Unity.Mathematics;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    private Quaternion startRotation;
    private Quaternion finalRoation;
    public float roatatingSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = Quaternion.Euler(0,-80,0);
    }

    // Update is called once per frame
    void Update()
    {
        finalRoation = quaternion.Euler(0,80,0);
        transform.localRotation = Quaternion.Lerp(startRotation,finalRoation, roatatingSpeed * Time.deltaTime);
    }
}
