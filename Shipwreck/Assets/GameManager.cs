using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    private bool isGameOver;
    private float originalTimeScale;

    private void Start()
    {
        isGameOver = false;
        originalTimeScale = Time.timeScale;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            // Show the game over screen
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
}
