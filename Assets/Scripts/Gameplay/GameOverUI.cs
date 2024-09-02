using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel; // Il pannello della UI di game over

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Nascondi la UI all'inizio
        }
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0; // Metti in pausa il gioco
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Mostra il pannello di game over
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Ripristina la velocità del tempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Ricarica la scena
    }
}
