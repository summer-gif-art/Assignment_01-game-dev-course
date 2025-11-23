using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _score;

    private void Awake()
    {
        // Make sure score starts at 0
        _score = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only react to coins
        if (!other.CompareTag("coin"))
            return;

        // Get coin value from the Coin script
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            _score += coin.value;
            Debug.Log("Score: " + _score);
        }

        // 1) Remove the collected coin from the scene
        Destroy(other.gameObject);

        // 2) Now check if there are NO coins left in the scene
        if (GameObject.FindGameObjectsWithTag("coin").Length == 0)
        {
            // 3) Find the spawner and ask it to spawn a new batch
            CoinSpawner spawner = UnityEngine.Object.FindFirstObjectByType<CoinSpawner>();
            if (spawner != null)
            {
                Debug.Log("All coins collected → spawning new batch");
                spawner.SpawnCoins();
            }
            else
            {
                Debug.LogWarning("No CoinSpawner found in the scene!");
            }
        }
    }
}
