using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public float moveSpeed = 2f;  // Velocità di movimento del terreno
    private float groundWidth;    // Larghezza dello sprite del terreno
    private Vector2 startPosition; // Posizione iniziale del terreno

    void Start()
    {
        // Calcola la larghezza del terreno dal suo SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            groundWidth = spriteRenderer.bounds.size.x;
        }
        else
        {
            Debug.LogError("SpriteRenderer non trovato sul terreno!");
        }

        // Memorizza la posizione iniziale del terreno
        startPosition = transform.position;
    }

    void Update()
    {
        // Movimento del terreno verso sinistra
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Se il terreno ha raggiunto metà della sua lunghezza verso sinistra, resettare la posizione
        if (transform.position.x <= startPosition.x - groundWidth / 2)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        // Resetta la posizione del terreno alla posizione iniziale
        transform.position = startPosition;
    }
}
