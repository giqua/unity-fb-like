using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 2f;

    private float timer = 0;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        float randomHeight = Random.Range(-heightOffset, heightOffset);
        Instantiate(pipePrefab, new Vector3(transform.position.x, randomHeight, 0), Quaternion.identity);
    }
}
