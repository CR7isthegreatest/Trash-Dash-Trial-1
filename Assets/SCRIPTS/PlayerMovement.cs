using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // reference to rigid body component
    public Rigidbody rb;

    public float fowardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 100f;

    public LayerMask groundMask;

    float horizontalInput = 0;
    bool wantingToJump = false;

    private void Update()
    {
        horizontalInput = 0;
        if (Input.GetKey(KeyCode.A)) horizontalInput--;
        if (Input.GetKey(KeyCode.D)) horizontalInput++;

        if (Input.GetKeyDown(KeyCode.Space)) wantingToJump = true;
    }

    // We marked this as fixed update
    // because we are using it to mess with physics
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        rb.AddForce(sidewaysForce * horizontalInput * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (wantingToJump)
        {
            wantingToJump = false;
            if (IsGrounded()) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (rb.position.y < -5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundMask);
    }
}
