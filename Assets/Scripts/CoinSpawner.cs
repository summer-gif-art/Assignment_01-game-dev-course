using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;   // Drag your Coin prefab here

    public Vector2 minRange = new Vector2(-50, -50);
    public Vector2 maxRange = new Vector2(50, 50);

    private int _coinsPerBatch = 5;

    void Start()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
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
    }
}