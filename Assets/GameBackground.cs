using UnityEngine;

public class GameBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite[] background;
    Rope rope;

    int backgroundIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        background = Resources.LoadAll<Sprite>("backgrounds");
        Debug.Log(background[0]);
        Debug.Log(background[1]);
        Debug.Log(background[2]);
        rope = GameObject.Find("rope").GetComponent<Rope>();

        spriteRenderer.sprite = background[0];
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(background[backgroundIndex]);

        if (rope.getcurrJumps() == 15)
            spriteRenderer.sprite = background[1];
        if (rope.getcurrJumps() == 30)
            spriteRenderer.sprite = background[2];
    }

    public void resetBackground()
    {
        spriteRenderer.sprite = background[0];
    }
}