using UnityEngine;

public class MoveStartCube : MonoBehaviour
{
    public float speed = 5f; // Adjust speed in Inspector

    void Update()
    {
        // Move with WASD keys
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);
    }
}