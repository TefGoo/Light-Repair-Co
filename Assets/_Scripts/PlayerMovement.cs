using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control movement speed
    private Rigidbody rb;
    private Vector3 moveInput;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>(); // Get the Rigidbody component from the child object
    }

    void Update()
    {
        if (canMove)
        {
            // Get player input
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate movement direction based on input
            moveInput = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        }
    }

    void FixedUpdate()
    {
        // Move the player
        Vector3 movement = transform.TransformDirection(moveInput) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // Method to enable/disable player movement
    public void SetCanMove(bool move)
    {
        canMove = move;
    }
}
