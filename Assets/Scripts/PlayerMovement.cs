using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // How fast the player moves
    public float moveSpeed = 5f;

    // Reference to the LoseText UI GameObject (assigned in Inspector)
    public GameObject loseText;
    
    // Reference to the Rigidbody2D component on the player
    private Rigidbody2D _pla;

    // Stores the input direction (x, y)
    private Vector2 _input;
    
    // Prevents multiple "Lose" triggers
    private bool _hasLost;

    private void Awake()
    {
        // Get the Rigidbody2D component from the same GameObject
        _pla = GetComponent<Rigidbody2D>();
        
        // Make sure the game is running (not paused)
        Time.timeScale = 1f;
        
        // Explicitly reset lose flag (optional, but removes confusion)
        _hasLost = false;
    }

    private void Update()
    {
        // If the player has already lost, stop movement input
        if (_hasLost)
            return;
        
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
        // Block movement physics when the player has lost
        if (_hasLost)
            return;
        
        // Move the player using Rigidbody2D
        // Time.fixedDeltaTime = fixed physics step
        _pla.MovePosition(_pla.position + Time.fixedDeltaTime * moveSpeed * _input);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            // If we hit an object tagged as "Enemy" → lose the game
            if (other.CompareTag("enemy"))
            {
                Lose();
            }
        }
    }
    private void Lose()
    {
        // Make sure Lose() only happens once
        if (_hasLost) return;

        _hasLost = true;

        // Print a message for debugging
        Debug.Log("You Lose!");

        // Show the LoseText UI element (if assigned)
        if (loseText != null)
            loseText.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }
}

