using UnityEngine;

public class Coin : MonoBehaviour
{
    // Coin type (0 = Blue, 1 = Green, 2 = Orange)
    public int coinType;

    // How many points this coin is worth
    public int value;

    // Reference to the SpriteRenderer
    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Called by the spawner after creation
    public void Setup(int type)
    {
        coinType = type;

        switch (type)
        {
            case 0: // Blue coin
                value = 10;
                _sr.color = Color.blue;
                break;

            case 1: // Green coin
                value = 20;
                _sr.color = Color.green;
                break;

            case 2: // Orange coin
                value = 50;
                _sr.color = new Color(1f, 0.5f, 0f); // orange
                break;
        }
    }
}