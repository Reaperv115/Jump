using UnityEngine;

public class GameBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite[] background;


    // Start is called before the first frame update
    void Start()
    {
        // getting the sprite renderer component of the background
        spriteRenderer = GetComponent<SpriteRenderer>();

        //loading all background sprites
        background = Resources.LoadAll<Sprite>("backgrounds");

        // setting the initial background display
        spriteRenderer.sprite = background[0];

    }

    // Update is called once per frame
    void Update()
    {
        // change the game background depending on how far the player gas made it
        if (PlayerManager.Instance.GetPlayerRef().GetNumJumpsthisTurn().Equals(50))
            spriteRenderer.sprite = background[1];
        if (PlayerManager.Instance.GetPlayerRef().GetNumJumpsthisTurn().Equals(100))
            spriteRenderer.sprite = background[2];

    }
    // reset the game background
    public void ResetBackground() { spriteRenderer.sprite = background[0]; }

}