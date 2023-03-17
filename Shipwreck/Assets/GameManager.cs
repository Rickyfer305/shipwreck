using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    private bool isGameOver;
    private float originalTimeScale;
    private PlayerController player;
    // public GameObject _kills;
    // public GameObject _coins;

    private void Start()
    {
        isGameOver = false;
        player = GetComponent<PlayerController>();
        originalTimeScale = Time.timeScale;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            // Show the game over screen
            // _kills.text = player.kills + " KILLS";
            // _coins.text = player.coins + " KILLS";
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        Time.timeScale = originalTimeScale;
        SceneManager.LoadScene("beta");
    }

    public void BackToMenu()
    {
        Debug.Log("Back to the menu");
        Time.timeScale = originalTimeScale;
        SceneManager.LoadScene("MainMenu");
    }
}
