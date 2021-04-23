using UnityEngine;

public class Background : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Sprite[] background;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = new Color(0.0f, 0.0f, 255f);
    }
    public void resetBackground()
    {
        spriteRenderer.sprite = background[0];
    }
}
