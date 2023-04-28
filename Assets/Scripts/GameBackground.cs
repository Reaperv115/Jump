using UnityEngine;

public class GameBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite[] background;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        background = Resources.LoadAll<Sprite>("backgrounds");
        spriteRenderer.sprite = background[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.GetNumofJumps().Equals(15))
            spriteRenderer.sprite = background[1];
        if (PlayerManager.Instance.GetNumofJumps().Equals(30))
            spriteRenderer.sprite = background[2];

    }
    public void ResetBackground()
    {
        spriteRenderer.sprite = background[0];
    }

}