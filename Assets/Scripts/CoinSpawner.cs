using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;   // Drag your Coin prefab here

    public Vector2 minRange = new Vector2(-50, -50);
    public Vector2 maxRange = new Vector2(50, 50);

    private int _coinsPerBatch = 5;
    
    // How many coins are currently alive in the scene
    private int _coinsAlive;
    
    private void Awake()
    {
        _coinsAlive = 0;
    }

    void Start()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        _coinsAlive = _coinsPerBatch;
        
        for (int i = 0; i < _coinsPerBatch; i++)
        {
            // Random position inside the range
            Vector2 pos = new Vector2(
                Random.Range(minRange.x, maxRange.x),
                Random.Range(minRange.y, maxRange.y)
            );

            // Create the coin
            GameObject c = Instantiate(coinPrefab, pos, Quaternion.identity);

            // Random type 0,1,2
            int type = Random.Range(0, 3);

            // Give the coin its type/color/value
            c.GetComponent<Coin>().Setup(type);
        }
        Debug.Log("Spawned new batch of coins. Alive = " + _coinsAlive);
    }
    // Called by the player whenever a coin is collected
    public void CoinCollected()
    {
        _coinsAlive--;
        Debug.Log("Coin collected. Coins left = " + _coinsAlive);

        if (_coinsAlive <= 0)
        {
            Debug.Log("All coins collected → Spawning new batch");
            SpawnCoins();
        }
    }
}