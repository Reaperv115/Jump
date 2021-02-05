using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask layermask;
    BoxCollider2D bc2d;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    { 
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    public bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, layermask);
        return hit.collider != null;
    }
}
