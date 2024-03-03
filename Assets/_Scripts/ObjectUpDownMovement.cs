using UnityEngine;

public class ObjectUpDownMovement : MonoBehaviour
{
    public float movementDistance = 1f; // Total distance to move up and down
    public float movementSpeed = 1f; // Speed of movement

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * movementSpeed) * movementDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
