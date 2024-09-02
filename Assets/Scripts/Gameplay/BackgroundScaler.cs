using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    void Start()
    {
        AdjustBackground();
    }

    void AdjustBackground()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("SpriteRenderer is missing!");
            return;
        }

        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight / Screen.height * Screen.width;

        Vector2 spriteSize = sr.sprite.bounds.size;

        transform.localScale = new Vector3(
            screenWidth / spriteSize.x,
            screenHeight / spriteSize.y,
            1);
    }
}
