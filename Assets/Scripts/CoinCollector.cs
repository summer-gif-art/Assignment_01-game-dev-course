using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _score;
    private CoinSpawner _spawner;

    private void Awake()
    {
        _score = 0;

        // Find the spawner once at startup and keep a reference
        _spawner = UnityEngine.Object.FindFirstObjectByType<CoinSpawner>();
        if (_spawner == null)
        {
            Debug.LogWarning("No CoinSpawner found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only react to objects tagged as "Coin"
        if (!other.CompareTag("coin"))
            return;

        // Read value from Coin component
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            _score += coin.value;
            Debug.Log("Score: " + _score);
        }

        // Destroy the coin
        Destroy(other.gameObject);

        // Tell the spawner that one coin was collected
        if (_spawner != null)
        {
            _spawner.CoinCollected();
        }
    }
}