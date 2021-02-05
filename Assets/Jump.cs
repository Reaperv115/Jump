using UnityEngine;

public class Jump : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rb2d = player.GetComponent<Rigidbody2D>();
    }

    public void jump()
    {
        if (player.GetComponent<Player>().isGrounded())
        {
            float jumpVelocity = 15f;
            rb2d.velocity = Vector2.up * jumpVelocity;
        }
    }
}
