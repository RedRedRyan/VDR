using UnityEngine;

public class MoveEndCube : MonoBehaviour
{
    public float speed = 5f; // Adjust speed in Inspector

    void Update()
    {
        // Custom IJKL movement (I=Forward, K=Backward, J=Left, L=Right)
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.I)) moveZ = 1f;  // Forward
        if (Input.GetKey(KeyCode.K)) moveZ = -1f; // Backward
        if (Input.GetKey(KeyCode.J)) moveX = -1f; // Left
        if (Input.GetKey(KeyCode.L)) moveX = 1f;   // Right

        transform.Translate(new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime);
    }
}