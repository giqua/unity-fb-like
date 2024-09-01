using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Distruggi i tubi una volta fuori dalla vista
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
