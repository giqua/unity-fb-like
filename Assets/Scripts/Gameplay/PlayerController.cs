using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    private bool isGameOver = false;
    public GameOverUI gameOverPanel;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return; // Evita di eseguire il codice più volte

        // Controlla se il giocatore ha colliso con un oggetto taggato come "Pipe" o "Ground"
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            // Esegui logica di fine partita
            GameOver();
        }
    }

    void GameOver()
    {
        if (isGameOver) return; // Evita di eseguire il codice più volte
        isGameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.ShowGameOver(); // Mostra il pannello di game over
        }
        Debug.Log("Game Over!");
    }
    void RestartGame()
    {
        Debug.Log("Restarting game...");
        Time.timeScale = 1; // Ripristina il tempo di gioco
        // Ricarica la scena corrente
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
