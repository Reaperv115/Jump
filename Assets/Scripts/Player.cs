using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask layermask;
    BoxCollider2D bc2d;
    Rigidbody2D rb2d;

    SpriteRenderer spriteRenderer;
    Sprite standingSprite;
    Sprite[] jumpingSprites;


    int jumpingIndex = 0;

    bool canJump = false;

    // Start is called before the first frame update
    void Start()
    { 
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        standingSprite = Resources.Load<Sprite>("jumping4");
        jumpingSprites = Resources.LoadAll<Sprite>("jumping");
    }

    void Update()
    {
        if (isGrounded())
        {
            spriteRenderer.sprite = standingSprite;
            canJump = true;
        }

        if (canJump && isGrounded())
        {
            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                if (t.phase == TouchPhase.Began)
                {
                    float jumpVelocity = 15f;
                    rb2d.velocity = Vector2.up * jumpVelocity;
                    canJump = false;
                    if (jumpingIndex == 3)
                    {
                        spriteRenderer.sprite = jumpingSprites[jumpingIndex];
                        jumpingIndex = 0;
                    }
                    else
                    {
                        spriteRenderer.sprite = jumpingSprites[jumpingIndex];
                        ++jumpingIndex;
                    }
                }
            }
        }

        
    }


    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, layermask);
        return hit.collider != null;
    }
}
