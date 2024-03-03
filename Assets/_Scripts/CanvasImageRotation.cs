using UnityEngine;
using UnityEngine.UI;

public class CanvasImageRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation

    void Update()
    {
        float rotationAngle = Mathf.Sin(Time.time * rotationSpeed) * 5f; // Oscillate between -5 and 5 degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }
}
