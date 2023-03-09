using UnityEngine;

public class CoinController: MonoBehaviour {

    private PlayerController player;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision detected!");
        if (other.CompareTag("Player")) {
            Debug.Log("Player collided with coin!");
            Destroy(gameObject); // Destroy the coin object
            player.RecollectCoin();
        }
    }
} 