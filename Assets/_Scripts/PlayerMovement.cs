using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control movement speed
    public Transform characterObject; // Reference to the child object to rotate
    public Animator animator; // Reference to the Animator component
    private Rigidbody characterRb; // Rigidbody component of the character object
    private Vector3 moveInput;
    private bool canMove = true;

    void Start()
    {
        characterRb = characterObject.GetComponent<Rigidbody>(); // Get the Rigidbody component of the character object
        if (characterRb == null)
        {
            Debug.LogError("No Rigidbody component found on the character object.");
        }

        if (animator == null)
        {
            Debug.LogError("No Animator component assigned to the PlayerMovement script.");
        }
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

            // Rotate the character object to face the direction of movement
            if (moveInput != Vector3.zero)
            {
                characterObject.rotation = Quaternion.LookRotation(moveInput);
            }

            // Set the animator parameters based on player movement
            animator.SetFloat("Speed", moveInput.magnitude); // Set Speed parameter based on the magnitude of moveInput
        }
        else
        {
            // If player cannot move, set Speed parameter to 0 for idle animation
            animator.SetFloat("Speed", 0f);
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // Move the character object
            characterRb.MovePosition(characterRb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // Method to enable/disable player movement
    public void SetCanMove(bool move)
    {
        canMove = move;
    }
}
