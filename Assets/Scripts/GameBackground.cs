using UnityEngine;

public class GameBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite[] background;
    Rope rope;
    GameObject player;


    bool checkforRope;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        background = Resources.LoadAll<Sprite>("backgrounds");
        player = GameObject.FindGameObjectWithTag("Player");
        checkforRope = false;

        spriteRenderer.sprite = background[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().GetIsPlaying())
            checkforRope = true;

        if (checkforRope)
            rope = GameObject.FindGameObjectWithTag("rope").GetComponent<Rope>();

        if (rope)
        {
            checkforRope = false;
            if (rope.GetCurrJumps() == 15)
                spriteRenderer.sprite = background[1];
            if (rope.GetCurrJumps() == 30)
                spriteRenderer.sprite = background[2];
        }
    }

    public void ResetBackground() => spriteRenderer.sprite = background[0];
}