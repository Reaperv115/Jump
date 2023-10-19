using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // layermask used in
    // IsGrounded check
    [SerializeField]
    LayerMask layermask;

    // different components
    //found on the player GO
    BoxCollider2D bc2d;
    Rigidbody2D rb2d;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    // bools for controlling game flow
    bool canJump = false;
    bool playimpactsoundEffect = false;
    bool gotCaught = false;

    // how high to jump
    float jumpVelocity;

    // how many jumps this turn
    int numjumpsthisTurn;
    

    // Start is called before the first frame update
    void Start()
    {
        // ensuring the object isn't destroyed
        // when switching scenes
        DontDestroyOnLoad(this.gameObject);

        // getting various components of the player
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        jumpVelocity = 15;
        numjumpsthisTurn = 0;
    }

    void Update()
    {
        if (GameManager.instance.gamehasStarted)
        {
            if (IsGrounded())
            {
                spriteRenderer.sprite = PlayerManager.Instance.GetStandingSprites()[PlayerManager.Instance.selectedPlayer];
                if (playimpactsoundEffect)
                {
                    audioSource.Play();
                    playimpactsoundEffect = false;
                }
                else
                    audioSource.Stop();
                canJump = true;
            }
        }
        if (canJump)
        {
            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                if (t.phase == TouchPhase.Began)
                {
                    playimpactsoundEffect = true;
                    rb2d.velocity = Vector2.up * jumpVelocity;
                    canJump = false;
                    int num = Random.Range(0, PlayerManager.Instance.GetJumpingSprites().Length);
                    spriteRenderer.sprite = PlayerManager.Instance.GetJumpingSprites()[num];
                }
            }
        }

    }

    // check to see if the player is "grounded"
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, layermask);
        return hit.collider != null;
    }

    public void SetPlayerJumpVelocity(int velocity) { jumpVelocity = velocity; }
    public int GetNumJumpsThisTurn() { return numjumpsthisTurn; }
    public void SetNumJumpsThisTurn(int numjumps) { numjumpsthisTurn = numjumps; }
    public bool GetGotCaught() { return gotCaught; }
    public void SetGotCaught(bool caught) { gotCaught = caught; }
}
