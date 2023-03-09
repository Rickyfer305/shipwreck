using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static int score = 0; // The score variable

    public static ScoreManager Instance; // Singleton pattern

    private void Awake() {
        // Singleton pattern: make sure only one instance of this object exists
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void IncrementScore(int value = 1) {
        score += value; // Add the value to the score
        Debug.Log("Score: " + score); // Print the score to the console (for testing)
    }

    public void ResetScore() {
        score = 0; // Reset the score to zero
    }
}
