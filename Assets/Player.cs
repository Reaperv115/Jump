using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask layermask;
    BoxCollider2D bc2d;
    Rigidbody2D rb2d;

    SpriteRenderer spriteRenderer;
    Sprite standingSprite, jumpingSprite;

    // Start is called before the first frame update
    void Start()
    { 
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        standingSprite = Resources.Load<Sprite>("jumping4");
        jumpingSprite = Resources.Load<Sprite>("jumping3");
    }

    void Update()
    {
        if (isGrounded())
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("jumping4");
            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                
                if (t.fingerId.Equals(0))
                {
                    float jumpVelocity = 15f;
                    rb2d.velocity = Vector2.up * jumpVelocity;

                }

               
            }
        }
        else
            spriteRenderer.sprite = Resources.Load<Sprite>("jumping3");
    }

    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, layermask);
        return hit.collider != null;
    }
}
