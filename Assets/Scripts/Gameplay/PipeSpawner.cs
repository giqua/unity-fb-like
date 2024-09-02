using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Prefab per il singolo tubo
    public float spawnRate = 2f; // Tempo tra uno spawn e l'altro
    public float minYPosition = -2f; // Posizione minima sull'asse Y per lo spawn
    public float maxYPosition = 2f; // Posizione massima sull'asse Y per lo spawn
    public float pipeGap = 2.5f; // Distanza tra i tubi nella coppia
    private float timer = 0f; // Timer per lo spawn
    private float pipeHeight; // Altezza del tubo

    void Start()
    {
        // Calcola l'altezza del tubo
        SpriteRenderer pipeSpriteRenderer = pipePrefab.GetComponent<SpriteRenderer>();
        if (pipeSpriteRenderer != null)
        {
            pipeHeight = pipeSpriteRenderer.bounds.size.y;
        }
        else
        {
            Debug.LogError("SpriteRenderer non trovato sul prefab del tubo!");
        }
        Debug.Log($"pipeHeight: {pipeHeight}");
        // Trova il GameObject che rappresenta il background
        GameObject ground = GameObject.Find("Ground");
        if (ground != null)
        {
            SpriteRenderer spriteRenderer = ground.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Calcola i limiti minimo e massimo sull'asse Y per i tubi
                float spriteHeight = spriteRenderer.bounds.size.y;
                float spriteTop = spriteRenderer.bounds.max.y;
                float spriteBottom = spriteRenderer.bounds.min.y;

                Debug.Log($"spriteHeight: {spriteHeight}, spriteTop: {spriteTop}, spriteBottom: {spriteBottom}");

                // Aggiusta leggermente i limiti per evitare che i tubi siano visibili
                maxYPosition = spriteTop + pipeHeight / 2; // Margine in alto
                minYPosition = spriteBottom - 0.3f ; // Margine in basso

                Debug.Log($"maxYPosition: {maxYPosition}, minYPosition: {minYPosition}");
            }
            else
            {
                Debug.LogError("SpriteRenderer non trovato sul ground!");
            }
        }
        else
        {
            Debug.LogError("Ground non trovato nella scena!");
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnPipePair();
            timer = 0f;
        }
    }

    void SpawnPipePair()
    {
        // Calcola una posizione centrale sull'asse Y per lo spawn del tubo in basso
        float yBottomPos = Random.Range(minYPosition, maxYPosition);
        // Calcola la posizione del tubo superiore
        float yTopPos = yBottomPos + pipeGap + pipeHeight;

        // Calcola le posizioni per i tubi superiore e inferiore tenendo conto dell'altezza del tubo
        Vector2 spawnPositionTop = new Vector2(transform.position.x, yTopPos);
        Vector2 spawnPositionBottom = new Vector2(transform.position.x, yBottomPos);

        // Crea la coppia di tubi
        Instantiate(pipePrefab, spawnPositionBottom, Quaternion.identity); // Tubo inferiore
        GameObject topPipe = Instantiate(pipePrefab, spawnPositionTop, Quaternion.identity); // Tubo superiore
        topPipe.transform.Rotate(0, 0, 180); // Ruota il tubo superiore
    }
}
