using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // How fast the player moves
    public float moveSpeed = 5f;

    // Reference to the Rigidbody2D component on the player
    private Rigidbody2D _rb;

    // Stores the input direction (x, y)
    private Vector2 _input;

    private void Awake()
    {
        // Get the Rigidbody2D component from the same GameObject
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Read keyboard input: A/D or Left/Right arrows
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Read keyboard input: W/S or Up/Down arrows
        float vertical = Input.GetAxisRaw("Vertical");

        // Create a direction vector and normalize it
        // (so diagonal movement is not faster)
        _input = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        // Move the player using Rigidbody2D
        // Time.fixedDeltaTime = fixed physics step
        _rb.MovePosition(_rb.position + Time.fixedDeltaTime * moveSpeed * _input);
    }
}