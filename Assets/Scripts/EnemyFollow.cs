using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // How fast the enemy moves towards the player
    public float moveSpeed = 9f;

    // Reference to the player's Transform (drag the Player here in the Inspector)
    public Transform player;

    // Reference to this enemy's Rigidbody2D
    private Rigidbody2D _ene;

    private void Awake()
    {
        // Get the Rigidbody2D component from this enemy GameObject
        _ene = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // If no player assigned, do nothing (avoid errors)
        if (player == null)
            return;

        // Direction from the enemy to the player (playerPos - enemyPos)
        Vector2 direction = ((Vector2)player.position - _ene.position).normalized;

        // Move the enemy towards the player using physics step
        _ene.MovePosition(_ene.position + Time.fixedDeltaTime * moveSpeed * direction);
    }
}